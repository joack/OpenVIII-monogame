﻿namespace FF8
{
    public partial class Kernel_bin
    {
        /// <summary>
        /// 115 abilities. Flags version in AbilityFlags and AbilitiyFlags2
        /// </summary>
        /// <see cref="https://github.com/alexfilth/doomtrain/wiki/Junctionable-Abilities"/>
        public enum Abilities :byte
        {
            None,
            HP_J,
            Str_J,
            Vit_J,
            Mag_J,
            Spr_J,
            Spd_J,
            Eva_J,
            Hit_J,
            Luck_J,
            Elem_Atk_J,
            ST_Atk_J,
            Elem_Def_J,
            ST_Def_J,
            Elem_Defx2,
            Elem_Defx4,
            ST_Def_Jx2,
            ST_Def_Jx4,
            Abilityx3,
            Abilityx4,
            Magic,
            GF,
            Draw,
            Item,
            Empty,
            Card,
            Doom,
            MadRush,
            Treatment,
            Defend,
            Darkside,
            Recover,
            Absorb,
            Revive,
            LVDown,
            LVUp,
            Kamikaze,
            Devour,
            MiniMog,
            HP_20,
            HP_40,
            HP_80,
            STR_20,
            STR_40,
            STR_60,
            VIT_20,
            VIT_40,
            VIT_60,
            MAG_20,
            MAG_40,
            MAG_60,
            SPR_20,
            SPR_40,
            SPR_60,
            SPD_20,
            SPD_40,
            EVA_30,
            LUCK_50,
            Mug,
            MedData,
            Counter,
            Return_Damage,
            Cover,
            Initiative,
            Move_HPUp,
            HPBonus,
            StrBonus,
            VitBonus,
            MagBonus,
            SprBonus,
            Auto_Protect,
            Auto_Shell,
            Auto_Reflect,
            Auto_Haste,
            AutoPotion,
            Expendx2_1,
            Expendx3_1,
            Ribbon,
            Alert,
            Move_Find,
            Enc_Half,
            Enc_None,
            RareItem,
            SumMag_10,
            SumMag_20,
            SumMag_30,
            SumMag_40,
            GFHP_10,
            GFHP_20,
            GFHP_30,
            GFHP_40,
            Boost,
            Haggle,
            Sell_High,
            Familiar,
            CallShop,
            JunkShop,
            TMag_RF,
            IMag_RF,
            FMag_RF,
            LMag_RF,
            TimeMag_RF,
            STMag_RF,
            SuptMag_RF,
            ForbidMag_RF,
            RecovMed_RF,
            STMed_RF,
            Ammo_RF,
            Tool_RF,
            ForbidMed_RF,
            GFRecovMed_RF,
            GFAblMed_RF,
            MidMag_RF,
            HighMag_RF,
            MedLVUp,
            CardMod,
        }
    }
}