using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Constants
{
    // Main files
    public static string fProducts = "Data/General/Products/Products.xml";
    public static string fReceipts = "Data/General/Receipt/Receipts.xml";
    public static string fReceiptDetails = "Data/General/Receipt/ReceiptDetails.xml";
    public static string fInvoices = "Data/General/Invoice/Invoices.xml";
    public static string fInvoiceDetails = "Data/General/Invoice/InvoiceDetails.xml";
    public static string fOrders = "Data/General/Order/Orders.xml";
    public static string fOrderDetails = "Data/General/Order/OrderDetails.xml";
    public static string fInventory = "Data/General/Inventory/Inventory.xml";
    public static string fProductInventorys = "Data/General/Inventory/ProductInventorys.xml";
    public static string fProductInvoices = "Data/General/Invoice/ProductInvoices.xml";
    public static string fProductInventorysStatus = "Data/General/Inventory/ProductInventorysStatus.xml";

    // Database file
    public static string fDataReceipts = "Data/Database/Receipt/Receipts.xml";
    public static string fDataReceiptDetails = "Data/Database/Receipt/ReceiptDetails.xml";
    public static string fDataInvoices = "Data/Database/Invoice/Invoices.xml";
    public static string fDataInvoiceDetails = "Data/Database/Invoice/InvoiceDetails.xml";
    public static string fDataOrders = "Data/Database/Order/Orders.xml";
    public static string fDataOrderDetails = "Data/Database/Order/OrderDetails.xml";
    public static string fDataInventory = "Data/Database/Inventory/Inventory.xml";
    public static string fDataImportInventory = "Data/Database/Inventory/ImportInventory.xml";

    public static string fDataProductInventorys = "Data/Database/Inventory/ProductInventorys.xml";
    public static string fDataProductInvoices = "Data/Database/Invoice/ProductInvoices.xml";
    public static string fDataProductInvoicesOrder = "Data/Database/Invoice/ProductInvoicesOrder.xml";

    public static string fDataProductInventorysStatus = "Data/Database/Inventory/ProductInventorysStatus.xml";
    public static string fDataProductImportInventorysStatus = "Data/Database/Inventory/ProductImportInventorysStatus.xml";

    public static string fDataAccounts = "Data/Database/User/Accounts.xml";
    public static string fDataCustomers = "Data/Database/Customer/Customers.xml";
    public static string fDataGuests = "Data/Database/Customer/Guests.xml";

    // Other files
    public static string fElectronics = "Data/General/Products/Electronics.xml";
    public static string fPorcelains = "Data/General/Products/Porcelains.xml";
    public static string fFoods = "Data/General/Products/Food.xml";

    // Unit
    public static string unitElectricPower = "kWh";
    public static string unitWarranty = "Months";
    public static string unitCurrency = "VND";

    // xml xpath
    public static string xpathProduct = "Product";

    // format
    public static string formatThousand = "#,##0.##";
    public static string formatWarranty = formatThousand + " " + unitWarranty;
    public static string formatElectricPower = formatThousand + " " + unitElectricPower;
    public static string formatDate = "dd/MM/yyyy";
    public static string formatDateTime = "dd/MM/yyyy HH:mm";
    public static string formatCurrency = formatThousand + " " + unitCurrency;
    public static string formatDiscount = "0\\%";

    public static int posCenter = 20;
    public static int bufferLength = 150;
    public static string dateNone = "01/01/0001";
    public static string strEsc = "0";
}
