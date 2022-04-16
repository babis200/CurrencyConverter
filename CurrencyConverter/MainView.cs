using CurrencyConverter.Models;
using CurrencyConverter.Services;

namespace CurrencyConverter
{
    public partial class MainView : Form
    {
        List<ExchangeRate> _rates = new List<ExchangeRate>();

        ServiceCollection _services;

        public MainView(ServiceCollection services, UserModel user)
        {
            InitializeComponent();

            _services = services;
            fromComboBox.DataSource = Enum.GetValues(typeof(Currency));
            //toComboBox.DataSource = Enum.GetValues(typeof(Currency));

            this.Text = $"Welcome, {user.Username}";
            fromComboBox.SelectedValueChanged += new EventHandler(ComboBox_SelectedValueChanged);
            //toComboBox.SelectedValueChanged += new EventHandler(ComboBox_SelectedValueChanged);

            //Το API δέχεται ημ/νιες μονο μέχρι 14 μέρες πριν
            dateTimePicker1.MinDate = DateTime.Today.AddDays(-14);
            dateTimePicker1.MaxDate = DateTime.UtcNow;
        }

        private async void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var date = dateTimePicker1.Value.Date;
            string from = fromComboBox.SelectedValue?.ToString();

            try
            {
                _rates.Add(await _services.CurrencyService.HistoricalExchangeRate(date, from));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα κλήσης fastFOREX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateView();
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateView()
        {
            foreach (ExchangeRate rate in _rates)
            {
                if(rate.Results is null) continue;
                foreach (KeyValuePair<string, string> res in rate.Results)
                {
                    dataGridView1.Rows.Add(
                        rate.Date.ToString("dd/MM/yyyy"),
                        rate.from,
                        res.Key,
                        res.Value
                        );
                }
            }
        }


    }

    /// <summary>
    /// 
    /// </summary>
    public enum Currency
    {
        AED,
        AFN,
        ALL,
        AMD,
        ANG,
        AOA,
        ARS,
        AUD,
        AWG,
        AZN,
        BAM,
        BBD,
        BDT,
        BGN,
        BHD,
        BIF,
        BMD,
        BND,
        BOB,
        BRL,
        BSD,
        BTN,
        BWP,
        BZD,
        CAD,
        CDF,
        CHF,
        CLF,
        CLP,
        CNH,
        CNY,
        COP,
        CUP,
        CVE,
        CZK,
        DJF,
        DKK,
        DOP,
        DZD,
        EGP,
        ERN,
        ETB,
        EUR,
        FJD,
        FKP,
        GBP,
        GEL,
        GHS,
        GIP,
        GMD,
        GNF,
        GTQ,
        GYD,
        HKD,
        HNL,
        HRK,
        HTG,
        HUF,
        IDR,
        ILS,
        INR,
        IQD,
        IRR,
        ISK,
        JMD,
        JOD,
        JPY,
        KES,
        KGS,
        KHR,
        KMF,
        KPW,
        KRW,
        KWD,
        KYD,
        KZT,
        LAK,
        LBP,
        LKR,
        LRD,
        LSL,
        LYD,
        MAD,
        MDL,
        MGA,
        MKD,
        MMK,
        MNT,
        MOP,
        MRU,
        MUR,
        MVR,
        MWK,
        MXN,
        MYR,
        MZN,
        NAD,
        NGN,
        NOK,
        NPR,
        NZD,
        OMR,
        PAB,
        PEN,
        PGK,
        PHP,
        PKR,
        PLN,
        PYG,
        QAR,
        RON,
        RSD,
        RUB,
        RWF,
        SAR,
        SCR,
        SDG,
        SEK,
        SGD,
        SHP,
        SLL,
        SOS,
        SRD,
        SYP,
        SZL,
        THB,
        TJS,
        TMT,
        TND,
        TOP,
        TRY,
        TTD,
        TWD,
        TZS,
        UAH,
        UGX,
        USD,
        UYU,
        UZS,
        VND,
        VUV,
        WST,
        XAF,
        XCD,
        XDR,
        XOF,
        XPF,
        YER,
        ZAR,
        ZMW,

    }
}
