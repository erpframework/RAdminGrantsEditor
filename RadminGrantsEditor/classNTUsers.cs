using System;
using System.Collections.Generic;
using System.Text;

namespace RadminGrantsEditor
{
    class NTUsersItem
    {
        public enum RadminRights
        {
            Control = 1,
            Telnet = 2,
            Redirect = 4,
            Files = 8,
            View = 16,
            TextChat = 32,
            VoiceChat = 64,
            Messages = 128,
            Shutdown = 256
        }

        public enum RadminRightsValue
        {
            Allow = 0,
            Deny = 1,
            Odd = 2
        }

        private UInt32 ByteArrayToInt32(byte[] Input)
        {
            UInt32 result = 0;
            if (Input != null && Input.Length <= 4)
            {
                result = (UInt32)(Input[0] +
                    (Input[1] << 8) +
                    (Input[2] << 16) +
                    (Input[3] << 24));
            }
            return result;
        }

        private byte[] byteCopy4(byte[] bytes, int offset)
        {
            byte[] result = new byte[4];
            result[0] = bytes[offset];
            result[1] = bytes[offset+1];
            result[2] = bytes[offset+2];
            result[3] = bytes[offset+3];
            return result;
        }

        //24 байта, которые хранятся в реестре в значении NtUsers, в них зашифрован SID
        private byte[] _hex = new byte[24];

        public byte[] Hex
        {
            get { return _hex; }
            set {
                _hex = value;
                Sid = string.Format("S-1-{0}-{1}-{2}-{3}-{4}-{5}",_hex[3],_hex[4],ByteArrayToInt32(byteCopy4(_hex,8)),ByteArrayToInt32(byteCopy4(_hex,12)),ByteArrayToInt32(byteCopy4(_hex,16)),ByteArrayToInt32(byteCopy4(_hex,20)));
            }
        }

        private bool _isgroup;

        public bool IsGroup
        {
            get { return _isgroup; }
            set { _isgroup = value; }
        }


        private string _sid = string.Empty;


        public string Sid
        {
            get { return _sid; }
            set {
                _sid = value;
                //Преобразуем символьный сид в бинарный
                string[] _s = _sid.Split('-');
                byte[] _h = new byte[24];
                _h[3] = Convert.ToByte(_s[2]);
                UInt32 id = 0;
                for (int i = 0; i < 5; i++)
                {
                    id = Convert.ToUInt32(_s[i + 3]);
                    _h[4 + (i * 4)] = (byte)(id & 255);
                    _h[5 + (i * 4)] = (byte)((id >> 8) & 255);
                    _h[6 + (i * 4)] = (byte)((id >> 16) & 255);
                    _h[7 + (i * 4)] = (byte)((id >> 24) & 255);
                }
                _hex = _h;
            }
        }

        private string _name = string.Empty;

        public string Name
        {
            get { 
                if (_name == string.Empty)
                    return _sid; 
                else
                    return _name; 
            }
            set { _name = value; }
        }
        private string _type = string.Empty;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private UInt16 _allow;

        public UInt16 Allow
        {
            get { return _allow; }
            set { _allow = value; }
        }
        private UInt16 _deny;

        public UInt16 Deny
        {
            get { return _deny; }
            set { _deny = value; }
        }

      /*
             01 00 Управление                    1    00000001
         02 00 Telnet                        2    00000010
         04 00 Перенаправление               4    00000100
         08 00 Передача файлов               8    00001000
         10 00 Просмотр                      16   00010000
         20 00 Текстовый чат                 32   00100000
         40 00 Голосовой чат                 64   01000000
         80 00 Передача текстовых сообщений  128  10000000
         00 01 Выключение                    256 100000000
*/
        public RadminRightsValue GetRightValue(RadminRights right)
        {
            RadminRightsValue result = RadminRightsValue.Odd;

            if (right.GetHashCode() <= 256)
            {
                if ((_allow & right.GetHashCode()) != 0)
                {
                    result = RadminRightsValue.Allow;
                }
                if ((_deny & right.GetHashCode()) != 0)
                {
                    result = RadminRightsValue.Deny;
                }
            }
            return result;
        }             
    }

    class NTUsers
    {
        private List<NTUsersItem> _list = new List<NTUsersItem>();

        public NTUsers()
        {
        }

        public NTUsers(byte[] data)
        {
            Parse(data);
        }

        private bool CompareArray(byte[] _a, byte[] _b)
        {
            if (_a.Length!=_b.Length) return false;
            for (int i = 0; i < _a.Length; i++)
            {
                if (_a[i] != _b[i]) return false;
            }
            return true;
        }

        public int Parse(byte[] data)
        {
            int count = 0;
            //Парсим информацию из реестра
            for (int i = 0; i < data.Length; i += 40)
            {
                //Если нет сигнатуры 0x24 то нам подсунули что-то иное, а не NtUsers!
                if (data[i + 3] != 0x24) break;
                UInt16 rights = (UInt16)((data[i + 8]) + (data[i + 9] << 8));
                //Разрешающие (true) или запрещающие (false) права
                bool _righttype = ((data[i + 4]) == 1) ? false : true;
                byte[] _sidhex = new byte[24];
                for (int j = 0; j < 24; j++)
                {
                    _sidhex[j] = data[i + j + 16];
                }
                bool found = false;
                NTUsersItem _ntu = null;
                foreach (NTUsersItem _nu in _list)
                {
                    //if (_nu.Hex == _sidhex)
                    if (CompareArray(_nu.Hex,_sidhex))
                    {
                        _ntu = _nu;
                        found = true;
                        break;
                    }
                }
                if (_ntu == null)
                {
                    _ntu = new NTUsersItem();
                    _ntu.Hex = _sidhex;
                }
                if (_righttype)
                    _ntu.Allow = rights;
                else 
                    _ntu.Deny = rights;
                if (!found)
                {
                    _list.Add(_ntu);
                    count++;
                }
            }
            return count;
        }

        public NTUsersItem GetItem(string sid)
        {
            NTUsersItem result = null;
            foreach (NTUsersItem nu in _list)
            {
                if (nu.Sid == sid)
                {
                    result = nu;
                    break;
                }
            }
            return result;
        }

        public List<NTUsersItem> Items
        {
            get { return this._list; }
        }

        public byte[] GetData()
        {
            byte[] result = null;
            int cnt = 0;
            //считаем все записи Allow и Deny
            foreach (NTUsersItem nu in _list)
            {
                if (nu.Allow != 0) cnt++;
                if (nu.Deny != 0) cnt++;
            }
            result = new byte[cnt * 40];
            cnt = 0;
            //Запрещающие права
            foreach (NTUsersItem nu in _list)
            {
                if (nu.Deny != 0)
                {
                    result[cnt + 3] = 0x24;
                    result[cnt + 4] = 1;
                    result[cnt + 8] = (byte)(nu.Deny & 255);
                    result[cnt + 9] = (byte)((nu.Deny >> 8) & 255);
                    result[cnt + 12] = 1;
                    result[cnt + 13] = 5;
                    for (int i = 0; i < 24; i++)
                    {
                        result[cnt + 16 + i] = nu.Hex[i];
                    }
                    //result[cnt + 19] = nu.Hex[3];

                    cnt += 40;
                }
            }
            //Разрешающие права
            foreach (NTUsersItem nu in _list)
            {
                if (nu.Allow != 0)
                {
                    result[cnt + 3] = 0x24;
                    result[cnt + 4] = 0;
                    result[cnt + 8] = (byte)(nu.Allow & 255);
                    result[cnt + 9] = (byte)((nu.Allow>>8) & 255);
                    result[cnt + 12] = 1;
                    result[cnt + 13] = 5;
                    for (int i = 0; i < 24; i++)
                    {
                        result[cnt + 16 + i] = nu.Hex[i];
                    }
                    //result[cnt + 19] = nu.Hex[3];
                    cnt += 40;
                }
            }
            return result;
        }
    }
}
