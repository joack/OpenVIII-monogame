﻿namespace OpenVIII
{
    public partial class Junction
    {
        #region Classes

        private class IGMData_Mag_Group : IGMData.Group.Base
        {
            #region Methods

            public static new IGMData_Mag_Group Create(params Menu_Base[] d) => Create<IGMData_Mag_Group>(d);

            public override void Hide() =>
                //depending on the mode it'll hide what's needed and show rest.
                Show();

            public override bool ITEMInputs(Menu_Base i, int pos = 0)
            {
                var ret = false;
                if (InputsModeTest(pos))
                {
                    var lastmode = (Mode)Junction.GetMode();
                    ret = base.ITEMInputs(i, pos);
                    if (ret)
                    {
                        if (!Junction.GetMode().Equals(lastmode))
                            Show();
                    }
                }
                return ret;
            }

            public override void ITEMShow(Menu_Base i, int pos = 0)
            {
                if (Junction != null)
                {
                    pos = cnv(pos);
                    switch (Junction.GetMode())
                    {
                        default:
                            if (pos < 1)
                                base.ITEMShow(i, pos);
                            else base.ITEMHide(i, pos);
                            break;

                        case Mode.Mag_Pool_Stat:
                        case Mode.Mag_Stat:
                            if (pos < 3)
                                base.ITEMShow(i, pos);
                            else base.ITEMHide(i, pos);
                            break;

                        case Mode.Mag_EL_A:
                        case Mode.Mag_Pool_EL_A:
                            if (pos > 0 && pos < 5)
                                base.ITEMShow(i, pos);
                            else base.ITEMHide(i, pos);
                            break;

                        case Mode.Mag_EL_D:
                        case Mode.Mag_Pool_EL_D:
                            if (pos > 0 && pos < 4 || pos == 5)
                                base.ITEMShow(i, pos);
                            else base.ITEMHide(i, pos);
                            break;

                        case Mode.Mag_ST_A:
                        case Mode.Mag_Pool_ST_A:
                            if (pos > 0 && pos < 3 || pos == 6 || pos == 7)
                                base.ITEMShow(i, pos);
                            else base.ITEMHide(i, pos);
                            break;

                        case Mode.Mag_ST_D:
                        case Mode.Mag_Pool_ST_D:
                            if (pos > 0 && pos < 3 || pos == 6 || pos == 8)
                                base.ITEMShow(i, pos);
                            else base.ITEMHide(i, pos);
                            break;
                    }
                }
            }

            public override void Refresh()
            {
                base.Refresh();
                Show();
            }

            private bool InputsModeTest(int pos)
            {
                pos = cnv(pos);
                switch (Junction.GetMode())
                {
                    case Mode.Mag_Pool_Stat:
                    case Mode.Mag_Pool_EL_A:
                    case Mode.Mag_Pool_EL_D:
                    case Mode.Mag_Pool_ST_A:
                    case Mode.Mag_Pool_ST_D:
                        if (pos == 2)
                            return true;
                        break;

                    case Mode.Mag_Stat:
                        if (pos == 0)
                            return true;
                        break;

                    case Mode.Mag_EL_A:
                    case Mode.Mag_EL_D:
                        if (pos == 3)
                            return true;
                        break;

                    case Mode.Mag_ST_A:
                    case Mode.Mag_ST_D:
                        if (pos == 6)
                            return true;
                        break;
                }
                return false;
            }

            #endregion Methods
        }

        #endregion Classes
    }
}