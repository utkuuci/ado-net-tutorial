namespace AdoNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            dgwProducts.DataSource = _productDal.GetAll(); 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product
                {
                    Name = tbxName.Text,
                    UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                    StockAmount = Convert.ToInt32(tbxStockAmount.Text)
                };
                _productDal.Add(product);
                dgwProducts.DataSource= _productDal.GetAll();
                MessageBox.Show("Product Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}