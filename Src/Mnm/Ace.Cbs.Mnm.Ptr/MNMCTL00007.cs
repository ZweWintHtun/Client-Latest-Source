using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00007 : AbstractPresenter, IMNMCTL00007
    {
        #region VIEW

        private IMNMVEW00007 view;
        public IMNMVEW00007 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }


        private void WireTo(IMNMVEW00007 view)
        {
            this.view = view;
            this.Initialize(this.view, this.getEntity());
        }

        private PFMDTO00053 getEntity()
        {
            PFMDTO00053 AppSettingEntity = new PFMDTO00053();

            //tlfEntity.Eno = this.view.EntryNo;
            //tlfEntity.GroupNo = this.view.GroupNo;
            //tlfEntity.Narration = this.view.Narration;

            return AppSettingEntity;
        }

        #endregion

        #region Main Method

        public void Save(string Saving, string Fixed)
        {
            bool Saving_isAccrued = false;
            bool Fixed_isAccrued = false;

            //Get Selected SavingAccount Item
            if ( this.view.SavingAccrued )
                Saving_isAccrued = true;

            else
                Saving_isAccrued = false;
            //Get Select FixedAccount Item
            if ( this.view.FixedAccrued )
                Fixed_isAccrued = true;

            else
                Fixed_isAccrued = false;

            //Update AppSettings
            CXClientWrapper.Instance.Invoke<IMNMSVE00007>(x => x.Save_InterestNature_Configuration(Saving_isAccrued, Fixed_isAccrued));

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {                
                this.view.Successful("MI90001"); //Update Successful
            }
        }

        public void SelectByKeyName()
        {
            //Select From AppSettings By KeyName
            IList<PFMDTO00053> ListAppSettDTO = CXClientWrapper.Instance.Invoke<IMNMSVE00007, PFMDTO00053>(x => x.SelectByKeyName("SavingInterestAccrued", "FixedDepositAccrued"));

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                foreach (PFMDTO00053 AppSettDto in ListAppSettDTO)
                {
                    if (AppSettDto.KeyName == "SavingInterestAccrued") //Check SavingInterestAccred or FixedAccrued
                    {
                        if (AppSettDto.KeyValue == "Accrued") //If Saving Accrued 
                            this.view.SavingAccrued = true;

                        else                                  //Not Saving Accrued
                            this.view.SavingNotAccrued = true;
                    }
                    else
                    {
                        if (AppSettDto.KeyValue == "Accrued") //If Fixed Accrued
                            this.view.FixedAccrued = true;
                        else
                            this.view.FixedNotAccrued = true; //Not Fixed Accrued
                    }
                }
            }
        }

        public  void ClearControls()
        {
            this.view.SavingAccrued = false;
            this.view.SavingNotAccrued= false;
            this.view.FixedAccrued = false;
            this.view.FixedNotAccrued = false;
        }


        #endregion
    }
}
