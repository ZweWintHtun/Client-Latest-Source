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
using System.Data;
using Ace.Cbs.Cx.Cle;
using System.Reflection;
using System.ComponentModel;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00102 : AbstractPresenter, ILOMCTL00102
    {


        static decimal maxValue = 0;
        #region Properties
        private ILOMVEW00102 _view;
        public ILOMVEW00102 View
        {
            get { return this._view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00102 view)
        {
            if (this._view == null)
            {
                this._view = view;
                this.Initialize(this._view, this.GetEntity());
            }
        }

        #endregion

        public void Print()
        {
            try
            {
                string header;
                if (!CXCOM00006.Instance.IsExceedTodayDate(this.View.startDate))
                {
                    if (!CXCOM00006.Instance.IsExceedTodayDate(this.View.endDate))
                    {
                        if (this.View.startDate > this.View.endDate)
                        {
                            CXUIMessageUtilities.ShowMessageByCode("MV00131");//Start Date must not be greater than End Date.
                        }
                        else
                        {
                            IList<LOMDTO00102> lstAllLoanRecord = CXClientWrapper.Instance.Invoke<ILOMSVE00102, IList<LOMDTO00102>>(x => x.GetLoanRecordList(this.View.townshipCode, this.View.startDate, this.View.endDate, this.View.LoanType));
                            if (lstAllLoanRecord.Count > 0)
                            {
                                string startDate = this.View.startDate.ToShortDateString();
                                string endDate = this.View.endDate.ToShortDateString();
                                string townshipCode = this.View.townshipCode.ToString();
                                if (this.View.LoanType == "AGLoan")
                                {
                                    header = "AGRICULTURAL LOAN Record Listing";
                                    CXUIScreenTransit.Transit("frmLOMVEW00101.ReportViewer", true, new object[] { lstAllLoanRecord, startDate, endDate, townshipCode, header, "AGLoan" });
                                }
                                else
                                {
                                    header = "LiveStock LOAN Record Listing";
                                    CXUIScreenTransit.Transit("frmLOMVEW00103.ReportViewer", true, new object[] { lstAllLoanRecord, startDate, endDate, townshipCode, header, "LSLoan" });
                                }
                            }
                            else
                            {
                                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                            }
                        }
                    }
                }
            }
            catch { }
        }

        public DataTable ToDataTable<T>(IList<LOMDTO00072> lstCropType)
        {
            DataTable table = new DataTable();
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prp = props[i];
                if (prp != null || !string.IsNullOrEmpty(prp.Name))
                {
                    try
                    {
                        if (prp.Name.ToString().ToLower() == "businesstype")
                        {
                            for (int j = 0; j < lstCropType.Count; j++)
                            {
                                table.Columns.Add(lstCropType[j].Desp.ToString());
                            }
                            continue;
                        }
                        table.Columns.Add(prp.Name);//, prp.PropertyType);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
            return table;
        }

        public DataTable ToGetDataTable<T>(IList<LOMDTO00102> lstRecords)
        {
            PropertyDescriptorCollection props =
        TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                try
                {
                    PropertyDescriptor prop = props[i];
                    table.Columns.Add(prop.Name);
                }
                catch { }                
            }
            object[] values = new object[table.Columns.Count];
            foreach (LOMDTO00102 item in lstRecords)
            {                
                try
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                        //values[i] = props[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }
                catch { }                
            }
            return table;
        }

        public DataSet PrintExel_New(string type)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataTable dtValue = new DataTable();
            List<string> cropType_lst;
            try
            {
                IList<LOMDTO00102> lstAllLoanRecord = CXClientWrapper.Instance.Invoke<ILOMSVE00102, IList<LOMDTO00102>>(x => x.GetLoanRecordList(this.View.townshipCode, this.View.startDate, this.View.endDate, this.View.LoanType));
                if (type == "AGLoan")
                {
                    IList<LOMDTO00072> lstCropType = CXCLE00002.Instance.GetListObject<LOMDTO00072>("LOMORM00072.SelectAllCropTypeCode", new object[] { true });
                    cropType_lst = (from value in lstCropType
                                    select value.Desp).ToList();

                    string[] CashControlGrandTotal = new string[5 + lstCropType.Count];

                    CashControlGrandTotal = this.IntializeValue(CashControlGrandTotal, "Grand Total");
                }
                else {
                    IList<LOMDTO00076> lstCropType = CXCLE00002.Instance.GetListObject<LOMDTO00076>("LOMORM00076.SelectAllLSBusinessCode", new object[] { true });
                    cropType_lst = (from value in lstCropType
                                    select value.Description).ToList();

                    string[] CashControlGrandTotal = new string[5 + lstCropType.Count];

                    CashControlGrandTotal = this.IntializeValue(CashControlGrandTotal, "Grand Total");
                }
                
                if (cropType_lst.Count > 0)
                {
                    dt.Columns.Add("Serial");
                    dt.Columns.Add("Village");
                    dt.Columns.Add("Advance Date");
                    dt.Columns.Add("Advance Total Amount");
                    dt.Columns.Add("Actual Date");
                    for (int i = 0; i < cropType_lst.Count; i++)
                    {
                        dt.Columns.Add(cropType_lst[i].ToString());
                    }
                    dt.Columns.Add("Total Amount");
                    dt.Columns.Add("Loan Amount");
                    dt.Columns.Add("Refund Date");
                    dt.Columns.Add("Payslip No");
                    dt.Columns.Add("Refund Total Amount");


                    object[] obj = new object[dt.Columns.Count];
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        obj[i] = dt.Columns[i].ColumnName;
                    }

                    dt.Rows.Add(obj);
                    object[] row = new object[dt.Columns.Count];
                  
                    DataRow drNew = dt.NewRow();
                    dt.Rows.InsertAt(drNew, 0);
                    DataRow drNew2 = dt.NewRow();
                    dt.Rows.InsertAt(drNew2, 1);

                    dtValue = ToGetDataTable<LOMDTO00102>(lstAllLoanRecord);
                    ds.Tables.Add(dt);
                    ds.Tables.Add(dtValue);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("tsbCRUD"), "ME00061");//Printing Error Occur.
            }
            return ds;
        }

        public string[] IntializeValue(string[] list, string firstindexword)
        {
            list[0] = firstindexword;
            for (int i = 1; i < list.Length; i++)
            {
                list[i] = "0";
            }
            return list;
        }

        #region Helper Method
        public LOMDTO00102 GetEntity()
        {
            LOMDTO00102 entity = new LOMDTO00102();
            entity.startDate = this.View.startDate;
            entity.endDate = this.View.endDate;
            entity.townshipCode = this.View.townshipCode;
            entity.loanType = this.View.LoanType;
            return entity;
        }
        #endregion

        private decimal CheckValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            return Convert.ToDecimal(value);
        }
    }
}
