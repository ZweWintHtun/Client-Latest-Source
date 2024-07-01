using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.CXClient;
using System.Windows.Forms;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00142 : AbstractPresenter, IMNMCTL00142
    {

        #region Properties

        IMNMVEW00142 view;
        public IMNMVEW00142 ViewData
        {
            set { this.wierTo(value); }
            get { return this.view; }
        }

        private void wierTo(IMNMVEW00142 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

     
        #endregion

        #region helper_method

        public void Show_Message(string msgCode)
        {
            CXUIMessageUtilities.ShowMessageByCode(msgCode);
        }

        #endregion

        #region Process

        public void ProcessInterest(string formName)
        {
            string sourceBr = CurrentUserEntity.BranchCode;
            int currentUserId = CurrentUserEntity.CurrentUserID;
            CXClientWrapper.Instance.ServiceResult.ErrorOccurred = false; //default false
            CXClientWrapper.Instance.ServiceResult.MessageCode = "";
            
                DateTime getdate =Convert.ToDateTime (view.date);

                if (formName == "Fixed Year End")
                {
                    CXClientWrapper.Instance.Invoke<IMNMSVE00142>(x => x.ProcessInterest(sourceBr, getdate, currentUserId));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred ==true)
                    {
                        CXClientWrapper.Instance.Invoke<IMNMSVE00142>(x => x.UpdateInterest(sourceBr, getdate, currentUserId));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                        {
                            this.ViewData.IsSuccessful = true;     //Save success
                            this.ViewData.TimerProgress.Start();
                            Show_Message(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }
                    else
                    {
                        this.ViewData.IsSuccessful = false;     // Interest Calculation Failed
                        this.ViewData.TimerProgress.Start();
                        Show_Message(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
                else if (formName == "Fixed Year End Prev")
                {
                    CXClientWrapper.Instance.Invoke<IMNMSVE00142>(x => x.checkDate(sourceBr, getdate));
                    string messCode = CXClientWrapper.Instance.ServiceResult.MessageCode;

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                    {                 
                        if (string.IsNullOrEmpty(messCode))
                        {

                            CXClientWrapper.Instance.Invoke<IMNMSVE00142>(x => x.ProcessInterestPrev(sourceBr, getdate, currentUserId));
                            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                            {
                                CXClientWrapper.Instance.Invoke<IMNMSVE00142>(x => x.UpdatePre(sourceBr, getdate, currentUserId));
                                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                                {
                                    this.ViewData.IsSuccessful = true;     //Save success
                                    this.ViewData.TimerProgress.Start();
                                    Show_Message(CXClientWrapper.Instance.ServiceResult.MessageCode);
                                }
                            }
                            else
                            {
                                this.ViewData.IsSuccessful = false;
                                this.ViewData.TimerProgress.Start();
                                Show_Message(CXClientWrapper.Instance.ServiceResult.MessageCode);

                            }
                        }
                        else
                        {
                            if (CXUIMessageUtilities.ShowMessageByCode(messCode) == DialogResult.Yes)
                            {
                                CXClientWrapper.Instance.Invoke<IMNMSVE00142>(x => x.ProcessInterestPrev(sourceBr, getdate, currentUserId));
                                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                                {
                                    CXClientWrapper.Instance.Invoke<IMNMSVE00142>(x => x.UpdatePre(sourceBr, getdate, currentUserId));
                                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                                    {
                                        this.ViewData.IsSuccessful = true;     //Save success
                                        this.ViewData.TimerProgress.Start();
                                        Show_Message(CXClientWrapper.Instance.ServiceResult.MessageCode);
                                    }
                                }
                                else
                                {
                                    this.ViewData.IsSuccessful = false;
                                    this.ViewData.TimerProgress.Start();
                                    Show_Message(CXClientWrapper.Instance.ServiceResult.MessageCode);

                                }
                            }
                        }
                        
                    }
                    else
                    {
                        this.ViewData.IsSuccessful = false;    
                        this.ViewData.TimerProgress.Start();
                        Show_Message(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
            

        }
        #endregion 
    }
}
