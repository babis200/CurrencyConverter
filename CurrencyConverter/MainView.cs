using CurrencyConverter.Models;
using CurrencyConverter.Services;

using Microsoft.VisualBasic;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CurrencyConverter
{
    public partial class MainView : Form
    {
        List<ExchangeRate> rates = new List<ExchangeRate>();
        
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
            dateTimePicker1.MaxDate = DateTime.Today;
        }


        private async void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var date = dateTimePicker1.Value.Date;
            string from = fromComboBox.SelectedValue?.ToString();


            rates.Add(await _services.CurrencyService.HistoricalExchangeRate(date, from));
            UpdateRates();
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateRates()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = rates;
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //TODO - Validate selected date is not > 14 days older
        }

        private async void fromComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var date = dateTimePicker1.Value.Date;
            string from = fromComboBox.SelectedValue?.ToString();
            string to = toComboBox.SelectedValue?.ToString();


            rates.Add(await _services.CurrencyService.HistoricalExchangeRate(date, from));
            UpdateRates();
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
