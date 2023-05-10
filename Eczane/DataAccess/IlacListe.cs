using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eczane.DataAccess
{
    public class IlacListe
    {
        int _Id;
        string _barkod;
        string _IlacAdi;
        string _firma;
        double? _Fiyati;
        double? _KamuFiyat;
        double? _kamuOdenen;
        double? _depocuFiyat;
        double? _ImalatciFiyat;
        int _KDV;
        string _orijin;
        string _sgkKodu;
        string _atcKodu;
        string _recete;
        int _IlacFormID;
        string _KUB;
        int _Favori;
        byte[] _ambalajResim;
        public int ID
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }

        }
        public string barkod
        {
            get
            {
                return _barkod;
            }
            set
            {
                _barkod = value;
            }

        }
        public string IlacAdi
        {
            get
            {
                return _IlacAdi;
            }
            set
            {
                _IlacAdi = value;
            }

        }
        public string firma
        {
            get
            {
                return _firma;
            }
            set
            {
                _firma = value;
            }

        }

        public double Fiyati
        {
            get
            {
                return (double)_Fiyati;
            }
            set
            {
                _Fiyati = value;
            }

        }
        public double kamuFiyati
        {
            get
            {
                return (double)_KamuFiyat;
            }
            set
            {
                _KamuFiyat = value;
            }

        }
        public double kamuOdenen
        {
            get
            {
                return (double)_kamuOdenen;
            }
            set
            {
                _kamuOdenen = value;
            }

        }
        public double depocuFiyat
        {
            get
            {
                return (double)_depocuFiyat;
            }
            set
            {
                _depocuFiyat = value;
            }

        }

        public double ImalatciFiyat
        {
            get
            {
                return (double)_ImalatciFiyat;
            }
            set
            {
                _ImalatciFiyat = value;
            }

        }
        public int kdv
        {
            get
            {
                return _KDV;
            }
            set
            {
                _KDV = value;
            }

        }
        public string orijin
        {
            get
            {
                return _orijin;
            }
            set
            {
                _orijin = value;
            }

        }
        public string sgkKodu
        {
            get
            {
                return _sgkKodu;
            }
            set
            {
                _sgkKodu = value;
            }

        }
        public string atckodu
        {
            get
            {
                return _atcKodu;
            }
            set
            {
                _atcKodu = value;
            }

        }
        public string recete
        {
            get
            {
                return _recete;
            }
            set
            {
                _recete = value;
            }

        }
        public int IlacFormID
        {
            get
            {
                return _IlacFormID;
            }
            set
            {
                _IlacFormID = value;
            }

        }
        public string KUB
        {
            get
            {
                return _KUB;
            }
            set
            {
                _KUB = value;
            }

        }
        public int  Favori
        {
            get
            {
                return _Favori;
            }
            set
            {
                _Favori = value;
            }

        }
        public byte[] Amblajresim
        {
            get
            {
                return _ambalajResim;
            }
            set
            {
                _ambalajResim = value;
            }

        }
    }
}
