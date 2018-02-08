using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using System.IO;
using CSI.Business.Operation;
using CSI.Business.Master;

namespace Rubix.Screen.Form.Operation.K_Packing.Dialog
{
    public partial class dlgKPK022_PackingAppearance : DialogBase
    {
        #region Member

        private DataTable _dataTable = null;
        private PackingInstruction db = null;
        private Product _productdb = null;  
        private int countProduct = 0;
        private int indexPath = 0;
        #endregion

        enum eDataRow
        {
            ProductID
            ,ProductCode
            ,ProductShortCode
            ,ProductName
            ,ShipmentNo
            ,PackingNo            
        }

        #region Properties

        public DataTable dtDataResult
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new DataTable();
                }
                return _dataTable;
            }
            set
            {
                _dataTable = value;
            }
        }
        private PackingInstruction BusnessClass
        {
            get
            {
                if (db == null)
                {
                    db = new PackingInstruction();
                }
                return db;
            }
            set
            {
                db = value;
            }
        }
        public Product ProductBusinessClass
        {
            get
            {
                if (_productdb == null)
                    _productdb = new Product();
                return _productdb;
            }
            set
            {
                _productdb = value;
            }
        }

        #endregion

        #region Constructor
        public dlgKPK022_PackingAppearance()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
        } 
        #endregion

        #region Event Handler
        private void dlgKPK022_PackingAppearance_Load(object sender, EventArgs e)
        {
            base.HideStatusBar();
            indexPath = 0;
            countProduct = dtDataResult.Rows.Count;
            DataBinding();

            btnPrevious.Enabled = false;
            if (countProduct == 1)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            indexPath--;
            if (indexPath >= 0)
            {
                DataBinding();

                if (indexPath == 0)
                    btnPrevious.Enabled = false;
            }

            if (indexPath < countProduct - 1)
            {
                btnNext.Enabled = true;
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            indexPath++;
            if (indexPath < countProduct)
            {
                DataBinding();

                if (indexPath == countProduct - 1)
                    btnNext.Enabled = false;

            }


            if (indexPath > 0)
            {
                btnPrevious.Enabled = true;
            }
        } 
        #endregion

        #region Generic Function
        private void LoadImage(int ProductID)
        {
            byte[] imageByte = ProductBusinessClass.LoadImage(ProductID);

            pictureBox.Image = ControlUtil.ConvertByteToImage(imageByte);
        }

        private void DataBinding()
        {
            if (indexPath >= 0)
            {
                lblShipmentNo.Text = dtDataResult.Rows[indexPath]["ShipmentNo"].ToString();
                lblPackingNo.Text = dtDataResult.Rows[indexPath]["PackingNo"].ToString();
                lblProductShortCode.Text = dtDataResult.Rows[indexPath]["ProductShortCode"].ToString();
                lblProductCode.Text = dtDataResult.Rows[indexPath]["ProductCode"].ToString();
                lblProductName.Text = dtDataResult.Rows[indexPath]["ProductName"].ToString();

                LoadImage(Convert.ToInt32(dtDataResult.Rows[indexPath]["ProductID"]));

                lblPage.Text = indexPath + 1 + " / " + countProduct;
            }
        } 
        #endregion
    }
}