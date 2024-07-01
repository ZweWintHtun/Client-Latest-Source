using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00093 : AbstractPresenter ,ILOMCTL00093
    {
        #region Properties
        private ILOMVEW00093 view;
        public ILOMVEW00093 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00093 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetEntity());
        }
        #endregion

        #region Helper Method
        public LOMDTO00093 GetEntity()
        {
            LOMDTO00093 entity = new LOMDTO00093();
            entity.StartDate = this.view.StartDate;
            entity.EndDate = this.view.EndDate;
            entity.SourceBr = this.view.SourceBranch;
            entity.Cur = this.view.Currency;
            if (this.view.ParentFormName == "Agriculture Loans Reports")
            {
                entity.LoanType = "111"; 
            }
            else if (this.view.ParentFormName == "Livestock Loans Reports")
            {
                entity.LoanType = "112";
            }
            if (this.view.ReportType == "BySeasonType")
            {
                entity.SeasonDesp = this.view.SeasonType;
            }
            else if (this.view.ReportType == "ByCropType")
            {
                entity.CropDesp = this.view.CropType; 
            }            
            return entity;
        }

        private IList<LOMDTO00093> ChangeLOMDTO00094toLOMDTO00093(IList<LOMDTO00094> inputList)
        {
            IList<LOMDTO00093> outputList = new List<LOMDTO00093>();
            for (int i = 0; i < inputList.Count; i++)
            {
                LOMDTO00093 tempDto = new LOMDTO00093();
                tempDto.Id = inputList[i].Id;
                tempDto.Name = inputList[i].Name;
                tempDto.FatherName = inputList[i].FatherName;
                tempDto.Lno = inputList[i].Lno;
                tempDto.AcctNo = inputList[i].AcctNo;
                tempDto.LoanType = inputList[i].LoanType;
                tempDto.LoanProductType = inputList[i].LoanProductType;
                tempDto.VillageCode = inputList[i].VillageCode;
                tempDto.VillageDesp = inputList[i].VillageDesp;
                tempDto.CropCode = inputList[i].LSBusinessCode;
                tempDto.CropDesp = inputList[i].LSBusinessDesp;
                tempDto.SAmt = inputList[i].SAmt;
                tempDto.ExpireDate = inputList[i].ExpireDate;
                tempDto.IntRate = inputList[i].IntRate;
                tempDto.Penalties = inputList[i].Penalties;
                tempDto.GroupNo = inputList[i].GroupNo;
                tempDto.WithdrawDate = inputList[i].WithdrawDate;
                tempDto.LoanAmtPerAcre = inputList[i].LoanAmtPerAcre;
                tempDto.TotalAcre = inputList[i].TotalAcre;
                tempDto.Cur = inputList[i].Cur;
                tempDto.SourceBr = inputList[i].SourceBr;
                tempDto.StartDate = inputList[i].StartDate;
                tempDto.EndDate = inputList[i].EndDate;
                outputList.Add(tempDto);
            }
            return outputList;
        }

        private LOMDTO00093 ChangeDto(LOMDTO00094 inputDto)
        {
            LOMDTO00093 tempDto = new LOMDTO00093();
            tempDto.Id = inputDto.Id;
            tempDto.Name = inputDto.Name;
            tempDto.FatherName = inputDto.FatherName;
            tempDto.Lno = inputDto.Lno;
            tempDto.AcctNo = inputDto.AcctNo;
            tempDto.LoanType = inputDto.LoanType;
            tempDto.LoanProductType = inputDto.LoanProductType;
            tempDto.VillageCode = inputDto.VillageCode;
            tempDto.VillageDesp = inputDto.VillageDesp;
            tempDto.CropCode = inputDto.LSBusinessCode;
            tempDto.CropDesp = inputDto.LSBusinessDesp;
            tempDto.SAmt = inputDto.SAmt;
            tempDto.ExpireDate = inputDto.ExpireDate;
            tempDto.IntRate = inputDto.IntRate;
            tempDto.Penalties = inputDto.Penalties;
            tempDto.GroupNo = inputDto.GroupNo;
            tempDto.WithdrawDate = inputDto.WithdrawDate;
            tempDto.LoanAmtPerAcre = inputDto.LoanAmtPerAcre;
            tempDto.TotalAcre = inputDto.TotalAcre;
            tempDto.Cur = inputDto.Cur;
            tempDto.SourceBr = inputDto.SourceBr;
            tempDto.StartDate = inputDto.StartDate;
            tempDto.EndDate = inputDto.EndDate;
            return tempDto;
        }
        #endregion

        #region Methods

        public void Print()
        {
            if (this.Validate_Form())
            {
                if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.StartDate))
                {
                    if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.EndDate))
                    {
                        if (this.view.StartDate > this.view.EndDate)
                        {
                            CXUIMessageUtilities.ShowMessageByCode("MV00131");//Start Date must not be greater than End Date.
                        }
                        else
                        {
                            if (this.view.ReportType == "All")
                            {
                                LOMDTO00093 DTO = this.GetEntity();
                                IList<LOMDTO00093> DTOList = new List<LOMDTO00093>();
                                IList<LOMDTO00094> LSDTOList = new List<LOMDTO00094>();

                                if (this.view.ParentFormName == "Farm Loans Reports")
                                {
                                    DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00093, IList<LOMDTO00093>>(x => x.SelectAll(DTO));
                                    LSDTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00093, IList<LOMDTO00094>>(x => x.SelectAllLS(DTO));
                                    for (int i = 0; i < LSDTOList.Count; i++)
                                    {
                                        LOMDTO00093 resultDto = this.ChangeDto(LSDTOList[i]);
                                        DTOList.Add(resultDto);
                                    }
                                }
                                else
                                {
                                    if (DTO.LoanType == "111")
                                    {
                                        DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00093, IList<LOMDTO00093>>(x => x.SelectAllByLoanType(DTO));
                                    }
                                    else
                                    {
                                        LSDTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00093, IList<LOMDTO00094>>(x => x.SelectAllLiveStockByLoanType(DTO));
                                    }
                                }

                                if (DTOList.Count > 0)
                                {
                                    string startDate = this.view.StartDate.ToShortDateString();
                                    string endDate = this.view.EndDate.ToShortDateString();
                                    string currency = this.view.Currency.ToString();
                                    string sourcebranch = this.view.SourceBranch.ToString();
                                    string header = this.view.ParentFormName + " (All)";
                                    CXUIScreenTransit.Transit("frmLOMVEW00094.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header });
                                }
                                else if (LSDTOList.Count > 0)
                                {
                                    IList<LOMDTO00093> TempDTOList = this.ChangeLOMDTO00094toLOMDTO00093(LSDTOList);
                                    
                                    string startDate = this.view.StartDate.ToShortDateString();
                                    string endDate = this.view.EndDate.ToShortDateString();
                                    string currency = this.view.Currency.ToString();
                                    string sourcebranch = this.view.SourceBranch.ToString();
                                    string header = this.view.ParentFormName + " (All)";
                                    CXUIScreenTransit.Transit("frmLOMVEW00094.ReportViewer", true, new object[] { TempDTOList, startDate, endDate, currency, sourcebranch, header });
                                }
                                else
                                {
                                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                                }
                            }
                            else if (this.view.ReportType == "BySeasonType")
                            {
                                LOMDTO00093 DTO = this.GetEntity();
                                IList<LOMDTO00093> DTOList = new List<LOMDTO00093>();

                                if (this.view.ParentFormName == "Farm Loans Reports")
                                {
                                    DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00093, IList<LOMDTO00093>>(x => x.SelectAllBySeasonType(DTO));
                                }
                                else
                                {
                                    DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00093, IList<LOMDTO00093>>(x => x.SelectAllByLoanTypeBySeasonType(DTO));
                                }

                                if (DTOList.Count > 0)
                                {
                                    string startDate = this.view.StartDate.ToShortDateString();
                                    string endDate = this.view.EndDate.ToShortDateString();
                                    string currency = this.view.Currency.ToString();
                                    string sourcebranch = this.view.SourceBranch.ToString();
                                    string header = this.view.ParentFormName + " (By Season Type)";
                                    CXUIScreenTransit.Transit("frmLOMVEW00094.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header });
                                }
                                else
                                {
                                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                                }
                            }
                            else if (this.view.ReportType == "ByCropType")
                            {
                                LOMDTO00093 DTO = this.GetEntity();

                                IList<LOMDTO00093> DTOList = new List<LOMDTO00093>();
                                IList<LOMDTO00094> LSDTOList = new List<LOMDTO00094>();

                                if (this.view.ParentFormName == "Farm Loans Reports")
                                {
                                    DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00093, IList<LOMDTO00093>>(x => x.SelectAllByCropType(DTO));
                                }
                                else
                                {
                                    if (DTO.LoanType == "111")
                                    {
                                        DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00093, IList<LOMDTO00093>>(x => x.SelectAllByLoanTypeByCropType(DTO));
                                    }
                                    else if (DTO.LoanType == "112")
                                    {
                                        LSDTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00093, IList<LOMDTO00094>>(x => x.SelectAllByLoanTypeByBusinessType(DTO));
                                    }                                    
                                }

                                if (DTOList.Count > 0)
                                {
                                    string startDate = this.view.StartDate.ToShortDateString();
                                    string endDate = this.view.EndDate.ToShortDateString();
                                    string currency = this.view.Currency.ToString();
                                    string sourcebranch = this.view.SourceBranch.ToString();
                                    string header = this.view.ParentFormName + " (By Crop Type)";
                                    CXUIScreenTransit.Transit("frmLOMVEW00094.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header });
                                }
                                else if (LSDTOList.Count > 0)
                                {
                                    IList<LOMDTO00093> TempDTOList = this.ChangeLOMDTO00094toLOMDTO00093(LSDTOList);

                                    string startDate = this.view.StartDate.ToShortDateString();
                                    string endDate = this.view.EndDate.ToShortDateString();
                                    string currency = this.view.Currency.ToString();
                                    string sourcebranch = this.view.SourceBranch.ToString();
                                    string header = this.view.ParentFormName + " (By Crop Type)";
                                    CXUIScreenTransit.Transit("frmLOMVEW00094.ReportViewer", true, new object[] { TempDTOList, startDate, endDate, currency, sourcebranch, header });
                                }
                                else
                                {
                                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                                }
                            }

                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV00130");//End Date must not be greater than today. 
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV00129");//Start Date must not be greater than today.
                }
            }
        }

        #endregion
    }
}
