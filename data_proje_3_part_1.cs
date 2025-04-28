using System;
using System.Collections.Generic;

namespace data_proje_3_birinci_part
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] mahalleAdları = { "Evka 3", "Özkanlar", "Atatürk", "Erzene", "Kazımdirik" };
            YemekSiparişAğacı yemekSiparişAğacı = new YemekSiparişAğacı();
            yemekSiparişAğacı.ekleme(mahalleAdları[0]);
            yemekSiparişAğacı.ekleme(mahalleAdları[1]);
            yemekSiparişAğacı.ekleme(mahalleAdları[2]);
            yemekSiparişAğacı.ekleme(mahalleAdları[3]);
            yemekSiparişAğacı.ekleme(mahalleAdları[4]);
            yemekSiparişAğacı.inOrderYazdırma();
            Console.WriteLine("Ağacımızın derinliği: " + yemekSiparişAğacı.GetDerinlik());
            yemekSiparişAğacı.yüzElliLirayıGeçeniYazdır("Evka 3");
            Console.WriteLine("\n Menemen kaç adet söylendi: " + yemekSiparişAğacı.KaçAdetSöylendiyseDöndürVeYüzdeOnİndirimYap("Menemen"));
            Console.WriteLine("            indirimden sonraki fiyatlar: \n");
            yemekSiparişAğacı.inOrderYazdırma();
        }
    }
    class YemekSiparişAğacı
    {
        public Mahalle kök;
        private int derinlik = 0;
        public YemekSiparişAğacı()
        {
            kök = null;
        }
        public void ekleme(String mahalleAdı)
        {
            Mahalle eklenecekMahalle = new Mahalle(mahalleAdı);
            if (kök == null)
            {
                kök = eklenecekMahalle;
            }
            else
            {
                Mahalle şuAnki = kök;
                Mahalle biÜstü;
                while (true)
                {
                    biÜstü = şuAnki;
                    if (string.Compare(mahalleAdı, şuAnki.adı) == 1)
                    {
                        şuAnki = şuAnki.rightChild;
                        if (şuAnki == null)
                        {
                            biÜstü.rightChild = eklenecekMahalle;
                            return;
                        }
                    }
                    else
                    {
                        şuAnki = şuAnki.leftChild;
                        if (şuAnki == null)
                        {
                            biÜstü.leftChild = eklenecekMahalle;
                            return;
                        }
                    }
                }
            }
        }
        public void inOrderYazdırma()
        {
            inOrderYazdır(kök);
        }
        private void inOrderYazdır(Mahalle mahalle)
        {
            if (mahalle != null)
            {
                inOrderYazdır(mahalle.leftChild);
                mahalle.Yazdır();
                inOrderYazdır(mahalle.rightChild);
            }
        }
        public void DerinliğiGüncelle(Mahalle mahalle, int derinliği)
        {
            if (derinliği > derinlik && mahalle != null)
            {
                derinlik = derinliği;
            }
            if (mahalle != null)
            {
                DerinliğiGüncelle(mahalle.leftChild, derinliği + 1);
                DerinliğiGüncelle(mahalle.rightChild, derinliği + 1);
            }
        }
        public int GetDerinlik()
        {
            DerinliğiGüncelle(kök, 0);
            return derinlik;
        }
        public Mahalle AdıVerilenMahalleyiDöndür(Mahalle mahalle, string bulunacakMahalleninAdı)
        {
            if (mahalle != null && string.Compare(mahalle.adı, bulunacakMahalleninAdı) == 0)
            {
                return mahalle;
            }
            else
            {
                if (mahalle != null)
                {
                    AdıVerilenMahalleyiDöndür(mahalle.leftChild, bulunacakMahalleninAdı);
                    AdıVerilenMahalleyiDöndür(mahalle.rightChild, bulunacakMahalleninAdı);
                }
            }
            return null;
        }
        public void yüzElliLirayıGeçeniYazdır(string mahalleAdı)
        {
            Console.WriteLine("\n" + mahalleAdı + " mahallesinde 150 lirayı geçen siparişler aşağıda listelenecektir\n\n");
            for (int i = 0; i < AdıVerilenMahalleyiDöndür(kök, mahalleAdı).siparişlerListesi.Count; i++)
            {
                if (AdıVerilenMahalleyiDöndür(kök, mahalleAdı).siparişlerListesi[i].yüzElliLirayıGeçiyorMu())
                {
                    AdıVerilenMahalleyiDöndür(kök, mahalleAdı).siparişlerListesi[i].Yazdır();
                }
            }
        }
        public int KaçAdetSöylendiyseDöndürVeYüzdeOnİndirimYap(string ürünAdı)
        {
            return kök.siparişlerListesi[0].siparişbilgileri[0].KaçAdetSöylendiSonrasındaYüzdeOnİndirimYap(ürünAdı);
        }


    }
    class Mahalle
    {
        public Mahalle leftChild;
        public Mahalle rightChild;
        public string adı;
        public List<SiparişBilgileri> siparişlerListesi = new List<SiparişBilgileri>();

        public Mahalle(string mahalleAdı)
        {
            this.adı = mahalleAdı;
            Random rastgele = new Random();
            int sayi = rastgele.Next(5, 11);
            for (int i = 0; i < sayi; i++)
            {
                SiparişBilgileri sipariş = new SiparişBilgileri();
                siparişlerListesi.Add(sipariş);
            }
        }
        public void Yazdır()
        {
            Console.WriteLine("\n Mahallemizin adı:  " + adı);
            for (int i = 0; i < siparişlerListesi.Count; i++)
            {
                Console.WriteLine("\n \n   sipariş " + (i + 1) + ". ye" + " geçiyoruz ");
                siparişlerListesi[i].Yazdır();


            }
        }


    }
    class SiparişBilgileri
    {
        public List<TekBirUrun> siparişbilgileri = new List<TekBirUrun>();
        double toplamTutar = 0;

        public SiparişBilgileri()
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(3, 6);
            for (int i = 0; i < sayi; i++)
            {
                TekBirUrun ürün = new TekBirUrun();
                siparişbilgileri.Add(ürün);
                toplamTutar = toplamTutar + ürün.Fiyatı();
            }

        }
        public void Yazdır()
        {
            double toplamSiparişÜcreti = 0;
            for (int i = 0; i < siparişbilgileri.Count; i++)
            {
                Console.WriteLine(siparişbilgileri[i].ToString());
                toplamSiparişÜcreti = toplamSiparişÜcreti + siparişbilgileri[i].Fiyatı();
            }
            Console.WriteLine("Toplam Sipariş Ücreti: " + toplamSiparişÜcreti);
            Console.WriteLine("\n \n");
        }
        public bool yüzElliLirayıGeçiyorMu()
        {
            if (toplamTutar > 150)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class TekBirUrun
    {
        public string adı;
        public int adedi;
        public int adetUcretininSırası;
        private static string[] yemeklerVeİçecekler = { "Menemen", "Mantı", "Kebap", "Ayran", "Tavuk Döner", "Et Döner", "Ekmek Arası Ekmek Döner", "Sandviç", "Coca Cola", "Fanta", "Beyti", "Soğuk Çay" };
        public static double[] fiyatlar = { 10, 11, 20, 5, 8, 12, 6, 8, 7, 7, 20, 6 };
        public static int[] kaçAdetOldu = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public TekBirUrun()
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(1, 9);
            adedi = sayi;
            sayi = rastgele.Next(0, 12);
            adı = yemeklerVeİçecekler[sayi];
            kaçAdetOldu[sayi] = kaçAdetOldu[sayi] + adedi;
            adetUcretininSırası = sayi;
        }
        public string ToString()
        {
            return "Adı: " + adı + "  Adedi: " + adedi + " Toplam fiyatı: " + Fiyatı(); ;
        }
        public double Fiyatı()
        {
            return adedi * fiyatlar[adetUcretininSırası];
        }
        private void yuzde10indirim(int i)
        {
            fiyatlar[i] = (9 * fiyatlar[i]) / 10;
        }
        public int KaçAdetSöylendiSonrasındaYüzdeOnİndirimYap(string yemekYadaİçecek)
        {
            for (int i = 0; i < yemeklerVeİçecekler.Length; i++)
            {
                if (yemeklerVeİçecekler[i] == yemekYadaİçecek)
                {
                    yuzde10indirim(i);
                    return kaçAdetOldu[i];

                }

            }
            return 0;

        }
    }
}
