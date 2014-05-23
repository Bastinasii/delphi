using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//using System.Data.SqlServerCe;

namespace ProiectPAWInterfataSGBD
{
    public partial class PopulareTreeView : Form
    {
        //public static string connString = "user id=dima.david1;" +
        //                           "password=12345;server=localhost;" +
        //                           "database=david; " +
        //                           "connection timeout=10";
        //MySqlConnection cn = new MySqlConnection(connString);
        public static List<List<string>> colList = new List<List<string>>();
        public static List<string> tabList = new List<string>();
        public static string numeBD;
        private static string draggedNodeText;
        

        public void updateTree()
        {
            TreeNode nodBD = new TreeNode();

            nodBD.Text = numeBD;

            for(int i=0;i<tabList.Count;i++)
            {
                TreeNode nodTab = new TreeNode();
                nodTab.Text = tabList[i];
                for(int j=0;j<colList[i].Count;j++)
                {
                    TreeNode nodCol = new TreeNode();
                    nodCol.Text = colList[i][j];
                    nodTab.Nodes.Add(nodCol);
                }
                nodBD.Nodes.Add(nodTab);
            }
            treeView1.Nodes.Add(nodBD);
        }

        public PopulareTreeView()
        {
            InitializeComponent();

        }

        public PopulareTreeView(string numeBaza, List<List<string>> columnList, List<string> table)
        {
            
            InitializeComponent();
            colList = columnList;
            tabList = table;
            numeBD = numeBaza;
            updateTree();
        }

        private void PopulareTreeView_Shown(object sender, EventArgs e)
        {
            //try
            //{
            //    cn.Open();
            //}
            //catch (MySqlException ex)
            //{
            //    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    Application.ExitThread();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //treeView1.Nodes.Clear();

            //MySqlCommand cm = new MySqlCommand("SELECT * from Angajati",cn);

            //try
            //{
               
            //   MySqlDataReader datar = cm.ExecuteReader();

            //   while (datar.Read())
            //   {
            //       TreeNode nod = new TreeNode(datar["id"].ToString());
            //       nod.Nodes.Add(datar["nume"].ToString());
            //       TreeNode Nod2 = new TreeNode();
            //       nod.Nodes.Add(Nod2);
            //       Nod2.Text = "Mata";
            //       Nod2.Nodes.Add(new TreeNode("Tactu"));
                   

            //       //nod.Nodes.Add(datar["prenume"].ToString());
            //       //nod.Nodes.Add(datar["varsta"].ToString());
            //       nod.Nodes.Add(datar["Salariul"].ToString());
            //       treeView1.Nodes.Add(nod);

            //   }
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            }

        private void PopulareTreeView_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //Console.WriteLine("click!");
            
            //TreeNode ChildNode1 = new TreeNode();
            //ChildNode1.Text = "Next Child 1";
            //TreeNode ChildNode2 = new TreeNode();
            //ChildNode2.Text = "Next Child 2";
            //ChildNode1.Nodes.Add(ChildNode2);
            //treeView1.SelectedNode.Nodes.Add(ChildNode1);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {

            // Move the dragged node when the left mouse button is used. 
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

            // Copy the dragged node when the right mouse button is used. 
            else if (e.Button == MouseButtons.Right)
            {
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            treeView1.SelectedNode = treeView1.GetNodeAt(targetPoint);
            if(treeView1.SelectedNode != null)
            {
                draggedNodeText=treeView1.SelectedNode.Text;
            }
            
        }

        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node. 
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node,  
            // call the ContainsNode method recursively using the parent of  
            // the second node. 
            return ContainsNode(node1, node2.Parent);
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            try { 
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            //TreeNode targetNode = treeView1.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            Console.WriteLine(draggedNode.Text);
            draggedNodeText = draggedNode.Text;


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulareTreeView_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void PopulareTreeView_DragLeave(object sender, EventArgs e)
        {
            
            try
            {
                if(tabList.Exists(element => element == draggedNodeText))
                {
                EditQueryF f = new EditQueryF(FormularPrincipal.fMDI.getConnString(), draggedNodeText);
                f.MdiParent = FormularPrincipal.fMDI;
                f.Show();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        }

   
    }
