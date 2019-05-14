﻿using System.IO;

namespace FF8
{
    public partial class Kernel_bin
    {
        /// <summary>
        /// Enemy Attacks Data
        /// </summary>
        /// <see cref="https://github.com/alexfilth/doomtrain/wiki/Enemy-attacks"/>
        public class Enemy_Attacks_Data
        {
            public const int id = 3;
            public const int count = 384;
            //0x00	2 bytes Offset to attack name
            public ushort MagicID; //0x02	2 bytes Magic ID
            public byte CameraChange; //0x04	1 byte Camera Change
            public byte Unknown0; //0x05	1 byte Unknown
            public byte Attack_type;//0x06	1 byte Attack type
            public byte Attack_power;//0x07	1 byte Attack power
            public byte Attack_flags;//0x08	1 byte Attack flags
            public byte Unknown1;//0x09	1 byte Unknown
            public byte Element;//0x0A	1 byte Element
            public byte Unknown2;//0x0B	1 byte Unknown
            public byte StatusAttack;//0x0C	1 byte Status attack enabler
            public byte Attack_parameter;//0x0D	1 byte Attack Parameter
            public byte[] Statuses0;//0x0E	2 bytes status_0; //statuses 0-7
            public byte[] Statuses1;//0x10	4 bytes status_1; //statuses 8-31
            internal void Read(BinaryReader br)
            {
                br.BaseStream.Seek(2, SeekOrigin.Current);

                MagicID = br.ReadUInt16(); //0x02	2 bytes Magic ID
                CameraChange = br.ReadByte(); //0x04	1 byte Camera Change
                Unknown0 = br.ReadByte(); //0x05	1 byte Unknown
                Attack_type = br.ReadByte();//0x06	1 byte Attack type
                Attack_power = br.ReadByte();//0x07	1 byte Attack power
                Attack_flags = br.ReadByte();//0x08	1 byte Attack flags
                Unknown1 = br.ReadByte();//0x09	1 byte Unknown
                Element = br.ReadByte();//0x0A	1 byte Element
                Unknown2 = br.ReadByte();//0x0B	1 byte Unknown
                StatusAttack = br.ReadByte();//0x0C	1 byte Status attack enabler
                Attack_parameter = br.ReadByte();//0x0D	1 byte Attack Parameter
                Statuses0 = br.ReadBytes(2);//0x0E	2 bytes status_0; //statuses 0-7
                Statuses1 = br.ReadBytes(4);//0x10	4 bytes status_1; //statuses 8-31
            }
        }
    }
}