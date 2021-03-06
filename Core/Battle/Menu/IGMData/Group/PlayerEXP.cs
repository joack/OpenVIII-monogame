﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using OpenVIII.AV;
using OpenVIII.IGMDataItem;

namespace OpenVIII.IGMData.Group
{
    public class PlayerEXP : Base, IDisposable
    {
        #region Fields

        /// <summary>
        /// <para>The Speed the exp counts down.</para>
        /// <para>Cannot be 0.</para>
        /// The smaller the number the faster it'll Count down.
        /// </summary>
        /// <list type="bullet">
        /// <item>
        /// <term>1</term>
        /// <description>1000 per second</description>
        /// </item>
        /// <item>
        /// <term>2</term>
        /// <description>500 per second</description>
        /// </item>
        /// <item>
        /// <term>3</term>
        /// <description>333.333... per second</description>
        /// </item>
        /// <item>
        /// <term>4</term>
        /// <description>250 per second</description>
        /// </item>
        /// </list>
        private const float speedOfEarningExp = 4;

        /// <summary>
        /// Total exp left to earn.
        /// </summary>
        private int _exp;

        /// <summary>
        /// Are we in counting down exp mode.
        /// </summary>
        private bool countingDown;

        private bool disposedValue;

        /// <summary>
        /// The looping exp sound. Need to track the object here to stop the loop.
        /// </summary>
        private Audio EXPsnd;

        private Box header;

        /// <summary>
        /// Keeps remainder between cycles
        /// </summary>
        private double remaining;

        #endregion Fields

        #region Destructors

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~PlayerEXP()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        #endregion Destructors

        #region Properties

        public int EXP
        {
            get => _exp; set
            {
                _exp = value;
                RefreshEXP();
            }
        }

        public ConcurrentDictionary<Characters, int> EXPExtra { get; set; }
        public bool NoEarnExp { get; internal set; } = false;

        private bool remainEXP => (_exp > 0 || EXPExtra != null && EXPExtra.Count > 0);

        #endregion Properties

        #region Methods

        public static new PlayerEXP Create(params Menu_Base[] d) => Create<PlayerEXP>(d);

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        public override void Draw()
        {
            if (Enabled)
                header?.Draw();
            base.Draw();
        }

        public override bool Inputs_CANCEL() => false;

        public override bool Inputs_OKAY()
        {
            base.Inputs_OKAY();
            if (!countingDown && remainEXP)
            {
                countingDown = true;
                if (EXPsnd == null)
                    EXPsnd = Sound.Play(34, loop: true);
                return true;
            }

            if (countingDown && remainEXP)
            {
                countingDown = false;
                EXPsnd.Stop();
                EXPsnd = null;
                EXP = 0;
                return true;
            }
            return false;
        }

        public override bool Update()
        {
            if (countingDown)
            {
                if (remainEXP)
                {
                    if ((remaining += Memory.ElapsedGameTime.TotalMilliseconds / speedOfEarningExp) > 1)
                    {
                        if (EXP > 0)
                        {
                            EXP -= (int)remaining;
                        }
                        else
                        {
                            var total = 0;
                            if (EXPExtra != null)
                            {
                                foreach (var e in EXPExtra)
                                {
                                    if (e.Value > 0)
                                        total += (EXPExtra[e.Key] -= (int) remaining);
                                    RefreshEXP();
                                }

                                if (total <= 0)
                                    EXPExtra = null;
                            }
                        }
                        remaining -= (int)remaining;
                    }
                }
                else
                {
                    countingDown = false;
                    EXPsnd.Stop();
                    EXPsnd = null;
                }
            }
            return base.Update();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                header.Dispose();
                disposedValue = true;
            }
        }

        protected override void Init()
        {
            base.Init();
            Cursor_Status |= (Cursor_Status.Hidden | (Cursor_Status.Enabled | Cursor_Status.Static));
            header = new Box { Data = Strings.Name.EXP_received, Pos = new Rectangle(0, 0, CONTAINER.Width, 78), Title = Icons.ID.INFO, Options = Box_Options.Middle };
        }

        private void RefreshEXP()
        {
            foreach (var i in ITEM)
            {
                var tmpexp = EXP;
                if (EXPExtra != null && i.Damageable.GetCharacterData(out var c) && EXPExtra.TryGetValue(c.ID, out var bonus))
                    tmpexp += bonus;
                ((IGMData.PlayerExp)i).NoEarnExp = NoEarnExp;
                ((IGMData.PlayerExp)i).Exp = tmpexp;
            }
            header.Width = Width;
        }

        #endregion Methods
    }
}