using System;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tcm.Ptr
{
    //Individual Denomination Delete
   public class TCMCTL00011 : AbstractPresenter , ITCMCTL00011
   {
       #region Properties

       TLMDTO00015 Entity { get; set; }

       private ITCMVEW00011 view;
       public ITCMVEW00011 View
       {
           get { return this.view; }
           set { this.WireTo(value); }
          
       }
       #endregion

       #region Method
       private void WireTo(ITCMVEW00011 view)
       {
           if (this.view == null)
           {
               this.view = view;
               this.Initialize(this.view, this.GetCashDenoEntity());
           }
       }    
       public TLMDTO00015 GetCashDenoEntity()
       {
           TLMDTO00015 Entity = new TLMDTO00015();
           Entity.TlfEntryNo = this.view.EntryNo;          
           return Entity;
       }
       #endregion  
     
       #region Validation
     
       public void txtEntryNo_CustomValidating(object sender, ValidationEventArgs e)
       {
           if (e.HasXmlBaseError == false)
           {
               Entity = CXClientWrapper.Instance.Invoke<ITCMSVE00011, TLMDTO00015>(x => x.GetCashDenoByEntryNo(this.View.EntryNo, CurrentUserEntity.BranchCode));
               if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
               {
                   this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
               }
               if (Entity == null)
               {
                   this.View.Failure(CXMessage.MV90027);    //Invalid Entry No
                   this.view.InitializeControl();
               }
               else
               {
                   this.view.Type = Entity.AccountType;
                   this.view.Amount = Entity.Amount;
                   this.view.UserNo = Entity.UserNo;
                   this.view.CounterNo = Entity.CounterNo;
               }
           } 
       }
       
       #endregion
       
       #region MainMethod
     
       public void Save()
       {
           if (this.ValidateForm(this.GetCashDenoEntity()))
           {
               CXClientWrapper.Instance.Invoke<ITCMSVE00011, string>(x => x.Save(Entity));

               if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
               {
                   this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
               }
               else
               {
                   this.View.Successful(CXMessage.MI90003);
                   this.view.InitializeControl();
               }
           }
       }

       #endregion
   }
}
