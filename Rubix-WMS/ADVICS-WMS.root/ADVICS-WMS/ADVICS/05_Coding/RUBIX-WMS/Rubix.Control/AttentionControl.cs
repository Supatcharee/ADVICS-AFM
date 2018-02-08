using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSI.Business.Common;
using CSI.Business;
using CSI.Business.DataObjects;
using Rubix.Framework;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;

namespace Rubix.Control
{
    public partial class AttentionControl : DevExpress.XtraEditors.XtraUserControl
    {        

        #region Member
        private Attention db;
        const string ATTENTION_NODE = "ATTENTION_NODE";
        const int CHECKED_IMAGE_IDX = 13;
        const int CUSTOMER_IMAGE_IDX = 2;
        private Dictionary<int?, List<string>> listOfAttention;
        #endregion

        #region Properties
        private Attention BusinessClass
        {
            get 
            {
                if (db == null)
                {
                    db = new Attention();
                }
                return db;
            }
        }
        public List<int?> DistinctOwnerIDs { get; set; }
        public Dictionary<int?, List<string>> AttentionList
        {
            get 
            {
                if (listOfAttention == null)
                {
                    listOfAttention = new Dictionary<int?, List<string>>();
                }
                return listOfAttention;
            }
        }
        #endregion

        #region Constructor
        public AttentionControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Generic Function
        public void DataLoading()
        {
            try
            {
                if (!DesignMode)
                {
                    trlAttention.ClearNodes();
                    AttentionList.Clear();

                    if (DistinctOwnerIDs != null)
                    {
                        TreeListNode nodeLast = null;
                        foreach (int ownerID in DistinctOwnerIDs)
                        {
                            // add owner node
                            trlAttention.AppendNode(new object[] { BusinessClass.GetOwnerName(ownerID) }, null);
                            nodeLast = trlAttention.Nodes.LastNode;
                            nodeLast.ImageIndex = CUSTOMER_IMAGE_IDX;
                            nodeLast.SelectImageIndex = CUSTOMER_IMAGE_IDX;

                            // add attention node for each contact
                            List<sp_common_LoadAttention_Result> listAttention = BusinessClass.DataLoading(ownerID);
                            List<string> attentionList = new List<string>();
                            foreach (sp_common_LoadAttention_Result data in listAttention)
                            {
                                nodeLast.Nodes.Add(new object[] { data.attention, ownerID });
                                if (false == attentionList.Contains(data.attention))
                                {
                                    attentionList.Add(data.attention);
                                }
                            }
                            // default checked
                            foreach (TreeListNode node in nodeLast.Nodes)
                            {
                                node.Checked = true;
                                node.ImageIndex = CHECKED_IMAGE_IDX;
                                node.SelectImageIndex = CHECKED_IMAGE_IDX;
                                node.Tag = ATTENTION_NODE;
                            }

                            AttentionList.Add(ownerID, attentionList);
                        }
                        trlAttention.ExpandAll();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ToggleCheckNode(TreeListNode tln)
        {
            if (tln.Tag != null && tln.Tag.ToString() == ATTENTION_NODE)
            {
                tln.Checked = !tln.Checked;
                if (tln.Checked)
                {
                    tln.ImageIndex = CHECKED_IMAGE_IDX;
                    tln.SelectImageIndex = CHECKED_IMAGE_IDX;
                    AddAttention(DataUtil.Convert<int>(tln.GetValue(1)), tln.GetValue(0).ToString());
                }
                else
                {
                    tln.ImageIndex = -1;
                    tln.SelectImageIndex = -1;
                    RemoveAttention(DataUtil.Convert<int>(tln.GetValue(1)), tln.GetValue(0).ToString());
                }
            }

        }

        private void AddAttention(int? ownerID, string attention)
        {
            List<string> tempList = GetAttention(ownerID);
            if (false == tempList.Contains(attention))
            {
                tempList.Add(attention);
            }
        }

        private void RemoveAttention(int? ownerID, string attention)
        {
            List<string> tempList = GetAttention(ownerID);
            if (true == tempList.Contains(attention))
            {
                tempList.Remove(attention);
            }
        }

        private List<string> GetAttention(int? ownerID)
        {
            List<string> tempList = new List<string>();
            bool found = AttentionList.TryGetValue(ownerID, out tempList);
            return tempList;
        }
        #endregion

        #region Event Handler Function
        private void trlAttention_MouseClick(object sender, MouseEventArgs e)
        {
            ToggleCheckNode(trlAttention.FocusedNode);
        }
        private void trlAttention_AfterExpand(object sender, NodeEventArgs e)
        {
            trlAttention.Columns[0].BestFit();
        }
        #endregion
    }
}