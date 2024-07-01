using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Pfm.Ptr
{
    public class PFMCTL00078 : AbstractPresenter, IPFMCTL00078
    {
        #region Properties

        private IPFMVEW00078 view;
        public IPFMVEW00078 solidarityView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(IPFMVEW00078 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }        
        #endregion

        #region Validation
        public void txtGroupNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (string.IsNullOrEmpty(this.view.GroupNo.ToString()))
            {
                this.SetCustomErrorMessage(this.GetControl("txtGroupNo"), CXMessage.MV900151);
            }
        }
        public void txtNRCNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (string.IsNullOrEmpty(this.view.NRCNo.ToString()))
            {
                this.SetCustomErrorMessage(this.GetControl("txtNRCNo"), CXMessage.MV00004);
            }
            else if (!string.IsNullOrEmpty(this.view.NRCNo.ToString()))
            {
                if (this.view.NRCNo.Length < 6)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtNRCNo"), CXMessage.MV00004);
                    return;

                }
            }
        }

        public void txtNRC_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (string.IsNullOrEmpty(this.view.other.ToString()))
            {
                this.SetCustomErrorMessage(this.GetControl("txtNRC"), CXMessage.MV00004);
            }
        }

        public void cboStateCode_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.StateCodeForNRC == null)
            {
                this.SetCustomErrorMessage(this.GetControl("cboStateCode"), CXMessage.MV20004);
            }
        }

        public void cboTownshipCode_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.TownshipCodeForNRC == null)
            {
                this.SetCustomErrorMessage(this.GetControl("cboTownshipCode"), CXMessage.MV20005);
            }
        }

        public void cboNationalityCode_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.NationalityCodeForNRC == null)
            {
                this.SetCustomErrorMessage(this.GetControl("cboNationalityCode"), CXMessage.MV00003);
            }
        }

        public void cboVillage_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.VillageCode == null)
            {
                this.SetCustomErrorMessage(this.GetControl("cboVillage"), CXMessage.MP00081);
            }
        }
        #endregion

        #region Methods        
        public void Save(IList<PFMDTO00078> lstSolidarity, IList<PFMDTO00078> oldSolidarity = null)
        {
            try
            {                
                IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();

                if (this.solidarityView.Status.Equals("Save"))
                {
                    this.solidarityView.GroupNo = CXClientWrapper.Instance.Invoke<IPFMSVE00078, string>(x => x.SaveServerAndServerClient(lstSolidarity, dvcvList));
                   if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.solidarityView.Successful("MI00051", this.solidarityView.GroupNo);  
                    }
                    else
                    {
                        this.solidarityView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
                else
                {
                    foreach (PFMDTO00078 entity in lstSolidarity.AsEnumerable().Where(x => x.Id != 0 ).ToList()) 
                    {
                         entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        foreach (PFMDTO00078 firstObj in oldSolidarity)
                        {
                            dvcvList = GetChangedValueOfObject.GetChangedValueList(firstObj, entity);
                        }
                        CXClientWrapper.Instance.Invoke<IPFMSVE00078>(x => x.Update(entity, dvcvList, "Update"));
                    }     
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        oldSolidarity = null;
                        string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                        this.solidarityView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, "");
                        this.SetFocus("txtGroupNo");
                    }
                    else
                    {
                        this.solidarityView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.SetFocus("txtName");
                    }
                }
            }
            catch { }            
        }

        public void Delete(IList<PFMDTO00078> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            
            CXClientWrapper.Instance.Invoke<IPFMSVE00078>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                this.solidarityView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, "");
            else
                this.solidarityView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);         
        }

        public IList<PFMDTO00078> SelectByGroupNo(string groupNo)
        {
            try
            {
                return CXClientWrapper.Instance.Invoke<IPFMSVE00078, PFMDTO00078>(service => service.SelectByGroupNo(groupNo));
            }
            catch
            {
                throw;
            }
        }


        #endregion
    }
}
