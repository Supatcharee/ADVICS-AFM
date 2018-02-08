using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business.Master;

namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS051_Item_SalePerchasePrice : DialogBase
    {
        #region Member
        private Product _db = null;
        private Common.eScreenMode eScrenMode;
        private Customer customerdb = null;
        private Product productdb = null;
        private Privilege privilege = null;
        private Currency currencydb = null;
        private ProductInfomation proInfo = null;
        #endregion

        #region Properties
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
        }
        public Product BusinessClass
        {
            get
            {
                if (_db == null)
                    _db = new Product();
                return _db;
            }
            set
            {
                _db = value;
            }
        }
        public Customer CustomerBusinessClass
        {
            get
            {
                if (customerdb == null)
                {
                    customerdb = new Customer();
                }
                return customerdb;
            }
            set
            {
                customerdb = value;
            }
        }
        public Product ProductBusinessClass
        {
            get
            {
                if (productdb == null)
                {
                    productdb = new Product();
                }
                return productdb;
            }
            set
            {
                productdb = value;
            }
        }
        public Currency CurrencyBusinessClass
        {
            get
            {
                if (currencydb == null)
                {
                    currencydb = new Currency();
                }
                return currencydb;
            }
            set
            {
                currencydb = value;
            }
        }
        public Privilege PrivilegeBusinessClass
        {
            get
            {
                if (privilege == null)
                {
                    privilege = new Privilege();
                }
                return privilege;
            }
            set
            {
                privilege = value;
            }
        }
        public ProductInfomation ProductInfo
        {
            get
            {
                if (proInfo == null)
                {
                    return proInfo = new ProductInfomation();
                }
                return proInfo;
            }
            set
            {
                proInfo = value;
            }
        }
        #endregion

        #region Constructor
        public dlgXMSS051_Item_SalePerchasePrice()
        {
            InitializeComponent();
        }

        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this,
                    String.Format(Rubix.Screen.Common.GetMessage("I0047"), "")) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        SaveData();
                        DialogResult = DialogResult.OK;

                        return true;
                    }
                    
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            return false;
        }

        #endregion


        #region Event Handler

        private void dlgXMSS050_Product_SalePrice_Load(object sender, EventArgs e)
        {
            
            InitialControl();
            DataBinding();

            if (ScreenMode == Common.eScreenMode.Add)
            {
                dtEffectiveDateSale.EditValue     = DateTime.Now;
                //dtImplementDateSale.EditValue     = DateTime.Now;
                dtEffectiveDatePurchase.EditValue = DateTime.Now;
                //dtImplementDatePurchase.EditValue     = DateTime.Now;

                ControlUtil.EnableControl(true, this.Controls);
                ControlUtil.HiddenControl(false, m_toolBarSave);
            }
            else
            {
                ControlUtil.EnableControl(false, this.Controls);
                ControlUtil.HiddenControl(true, m_toolBarSave);
            }
                

            ControlUtil.HiddenControl(true, m_toolBarClear);
            ControlUtil.EnableControl(false, supplierControl);

        }

        #endregion

        #region Generic function


        private Boolean ValidateData()
        {

            Boolean errFlag = true;
            errorProvider.ClearErrors();

            ////Customer Code
            customerControl.RequireField = true;
            customerControl.ErrorText = Rubix.Screen.Common.GetMessage("I0249");
            if (!customerControl.ValidateControl())
            {
                errFlag = false;
            }

            ////Sale Price
            if (txtSalePrice.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtSalePrice, Rubix.Screen.Common.GetMessage("I0355"));
                errFlag = false;
            }

            ////Currency Sale
            if (cboCurrencySale.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(cboCurrencySale, Rubix.Screen.Common.GetMessage("I0356"));
                errFlag = false;
            }

            ////Purchase Price
            if (txtPurchasePrice.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtPurchasePrice, Rubix.Screen.Common.GetMessage("I0359"));
                errFlag = false;
            }

            ////Currency Purchase
            if (cboCurrencyPurchase.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(cboCurrencyPurchase, Rubix.Screen.Common.GetMessage("I0356"));
                errFlag = false;
            }


            ////EffectiveDate Sale
            if (dtEffectiveDateSale.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(dtEffectiveDateSale, Rubix.Screen.Common.GetMessage("I0071"));
                errFlag = false;
            }
            else if (Convert.ToDateTime(dtEffectiveDateSale.EditValue) < DateTime.Today)
            {
                errorProvider.SetError(dtEffectiveDateSale, Rubix.Screen.Common.GetMessage("I0354"));
                errFlag = false;
            }

            

            ////Implement Sale
            //if (dtImplementDateSale.Text.Trim() == String.Empty)
            //{
            //    errorProvider.SetError(dtImplementDateSale, Rubix.Screen.Common.GetMessage(""));
            //    errFlag = false;
            //}
            if (dtImplementDateSale.Text.Trim() != String.Empty)
            {
                if (Convert.ToDateTime(dtImplementDateSale.EditValue) < DateTime.Today)
                {
                    errorProvider.SetError(dtImplementDateSale, Rubix.Screen.Common.GetMessage("I0354"));
                    errFlag = false;
                }
                else if (Convert.ToDateTime(dtImplementDateSale.EditValue) < Convert.ToDateTime(dtEffectiveDateSale.EditValue))
                {
                    errorProvider.SetError(dtImplementDateSale, Rubix.Screen.Common.GetMessage("I0379"));
                    errFlag = false;
                }
            }


            ////EffectiveDate Purchase
            if (dtEffectiveDatePurchase.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(dtEffectiveDatePurchase, Rubix.Screen.Common.GetMessage("I0071"));
                errFlag = false;
            }
            else if (Convert.ToDateTime(dtEffectiveDatePurchase.EditValue) < DateTime.Today)
            {
                errorProvider.SetError(dtEffectiveDatePurchase, Rubix.Screen.Common.GetMessage("I0354"));
                errFlag = false;
            }

            ////Implement Purchase
            if (dtImplementDatePurchase.Text.Trim() != String.Empty)
            {
                if (Convert.ToDateTime(dtImplementDatePurchase.EditValue) < DateTime.Today)
                {
                    errorProvider.SetError(dtImplementDatePurchase, Rubix.Screen.Common.GetMessage("I0354"));
                    errFlag = false;
                }
                else if (Convert.ToDateTime(dtImplementDatePurchase.EditValue) < Convert.ToDateTime(dtEffectiveDatePurchase.EditValue))
                {
                    errorProvider.SetError(dtImplementDatePurchase, Rubix.Screen.Common.GetMessage("I0379"));
                    errFlag = false;
                }
            }



            return errFlag;
        }
        
        
        private void DataBinding()
        {

            supplierControl.SupplierID          = ProductInfo.SupplierID;
            customerControl.CustomerID          = ProductInfo.CustomerID;
            txtSalePrice.EditValue              = ProductInfo.SalePrice;
            cboCurrencySale.EditValue           = ProductInfo.CurrencyID_Sale;
            txtHSCode.Text                      = ProductInfo.HSCode;
            txtIncotermSale.Text                = ProductInfo.Incoterm_Sale;
            dtEffectiveDateSale.EditValue       = ProductInfo.EffectiveDate_Sale;
            dtImplementDateSale.EditValue       = ProductInfo.ImplementDate_Sale;
            txtRemarkSale.Text                  = ProductInfo.Remark_Sale;

            txtPurchasePrice.EditValue          = ProductInfo.PurchasePrice;
            txtIncotermPurchase.Text            = ProductInfo.Incoterm_Purchase;
            dtEffectiveDatePurchase.EditValue   = ProductInfo.EffectiveDate_Purchase;
            dtImplementDatePurchase.EditValue   = ProductInfo.ImplementDate_Purchase;
            cboCurrencyPurchase.EditValue       = ProductInfo.CurrencyID_Purchase;
            txtRemarkPurchase.Text              = ProductInfo.Remark_Purchase;

            if (ScreenMode != Common.eScreenMode.Add)
            {
                if (string.IsNullOrEmpty(txtSalePrice.Text) && string.IsNullOrEmpty(txtPurchasePrice.Text))
                {
                    ControlUtil.ClearControlData(this.Controls);
                }

            }
            
        }


        private void SaveData()
        {
            //Sale
            ProductInfo.CustomerID              = customerControl.CustomerID;
            ProductInfo.SalePrice               = DataUtil.Convert<decimal>(txtSalePrice.EditValue);
            ProductInfo.CurrencyID_Purchase     = Convert.ToInt32(cboCurrencyPurchase.EditValue);
            ProductInfo.EffectiveDate_Sale      = Convert.ToDateTime(dtEffectiveDateSale.EditValue);
            ProductInfo.ImplementDate_Sale      = DataUtil.Convert<DateTime>(dtImplementDateSale.EditValue);
            ProductInfo.Incoterm_Sale           = txtIncotermSale.Text;
            ProductInfo.HSCode                  = txtHSCode.Text;
            ProductInfo.Remark_Sale             = txtRemarkSale.Text;
            ProductInfo.PVID                    = DataUtil.Convert<int>(cboPVSale.EditValue);

            //Purchase
            ProductInfo.CurrencyID_Sale         = Convert.ToInt32(cboCurrencySale.EditValue);
            ProductInfo.PurchasePrice           = DataUtil.Convert<decimal>(txtPurchasePrice.EditValue);
            ProductInfo.EffectiveDate_Purchase  = Convert.ToDateTime(dtEffectiveDatePurchase.EditValue);
            ProductInfo.ImplementDate_Purchase  = DataUtil.Convert<DateTime>(dtImplementDatePurchase.EditValue);
            ProductInfo.Incoterm_Purchase       = txtIncotermPurchase.Text;
            ProductInfo.Remark_Purchase         = txtRemarkPurchase.Text;



        }

        private void InitialControl()
        {
            customerControl.OwnerID = ProductInfo.OwnerID;
            customerControl.DataLoading();
            supplierControl.OwnerID = ProductInfo.OwnerID;
            supplierControl.DataLoading();
            supplierControl.SupplierID = ProductInfo.SupplierID;

            cboCurrencySale.Properties.DataSource        = CurrencyBusinessClass.DataLoading(null, null);
            cboCurrencySale.Properties.ValueMember       = "CurrencyID";
            cboCurrencySale.Properties.DisplayMember     = "CurrencyCode";

            cboCurrencyPurchase.Properties.DataSource    = CurrencyBusinessClass.DataLoading(null, null);
            cboCurrencyPurchase.Properties.ValueMember   = "CurrencyID";
            cboCurrencyPurchase.Properties.DisplayMember = "CurrencyCode";

            cboPVSale.Properties.DataSource              = PrivilegeBusinessClass.DataLoading(null, null);
            cboPVSale.Properties.ValueMember             = "PVID";
            cboPVSale.Properties.DisplayMember           = "PVCode";

        }
        #endregion

    }
}