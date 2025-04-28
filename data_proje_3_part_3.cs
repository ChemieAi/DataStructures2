using System;
using System.Collections.Generic;

namespace data_proje_3_part_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Mahalle mahalle1 = new Mahalle("ERZENE", 35135);
            Mahalle mahalle2 = new Mahalle("KAZIMDİRİK", 33934);
            Mahalle mahalle3 = new Mahalle("YEŞİLOVA", 33934);
            Mahalle mahalle4 = new Mahalle("ATATÜRK", 28912);
            Mahalle mahalle5 = new Mahalle("İNÖNÜ", 25778);
            Mahalle mahalle6 = new Mahalle("MEVLANA", 25492);
            Mahalle mahalle7 = new Mahalle("DOĞANLAR", 21461);
            Mahalle mahalle8 = new Mahalle("EVKA 3", 20445);
            Mahalle mahalle9 = new Mahalle("RAFET PAŞA", 19476);
            Mahalle mahalle10 = new Mahalle("KIZILAY", 15795);
            Heap maxHeapımız = Heap.GetHeap();
            maxHeapımız.Ekle(mahalle1);
            maxHeapımız.Ekle(mahalle2);
            maxHeapımız.Ekle(mahalle3);
            maxHeapımız.Ekle(mahalle4);
            maxHeapımız.Ekle(mahalle5);
            maxHeapımız.Ekle(mahalle6);
            maxHeapımız.Ekle(mahalle7);
            maxHeapımız.Ekle(mahalle8);
            maxHeapımız.Ekle(mahalle9);
            maxHeapımız.Ekle(mahalle10);
            Console.WriteLine("         Şimdi eklediğimiz tüm mahalleleri sırasıyla yazdıracağız");
            maxHeapımız.Yazdır();
            Console.WriteLine("\n    Şimdi ise ödevde istenildiği üzere en yüksek nüfuslu 3 mahalleyi çekiyoruz");
            maxHeapımız.EnYüksek3();



        }
    }
    public class Mahalle
    {
        public string adı;
        public int nüfusu;

        public Mahalle(string adı, int nüfusu)
        {
            this.adı = adı;
            this.nüfusu = nüfusu;
        }
        public string ToString()
        {
            return "Mahalle adı: " + adı + "\n      Mahallenin nüfusu: " + nüfusu + "\n";
        }
    }
    public class Heap //Max heap yazdık direkt olarak.
    {
        List<Mahalle> listem = new List<Mahalle>();
        static Heap a;
        private Heap() //Burada tek nesne olmasını istediğimiz için böyle bir yol izledik. Tek bir heap  bu ödevde yetiyor. 
        {
        }
        public static Heap GetHeap()
        {
            if (a == null)
            {
                a = new Heap();
                return a;
            }
            else
            {
                return a;
            }
        }
        public void Ekle(Mahalle mahalle)
        {
            if (listem.Count == 0)
            {
                listem.Add(new Mahalle("abc", 123));));//0. elemanı hiç kullanmayacağız. İlk elemanı boş bırakmak kolaylık sağlıyor.
            }
            listem.Add(mahalle);
            Console.WriteLine("eklendi");
            YeriniDüzelt(listem.Count);
        }
        public void Sil()
        {
            int sıra = 1;
            listem[sıra] = listem[listem.Count];
            listem.RemoveAt(listem.Count);
            Console.WriteLine("max heap kuralına göre kökteki eleman silindi");
            YeriniDüzelt(sıra);
        }
        public void Yazdır()
        {
            for (int i = 1; i < listem.Count; i++)
            {
                Console.WriteLine(i + ". eleman=> " + listem[i].ToString());
            }
        }
        public void EnYüksek3()
        {
            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine(i + ". eleman=> " + listem[i].ToString());
            }
        }
        public void YeriniDüzelt(int sıra)
        {
            if (listem.Count > 2) //İlk elemanı boş eleman olarak biz ekleyeceğiz. Listenin 1 den başlaması kolaylık sağlıyor.
            {
                int atasi;
                if (sıra / 2 == 1)
                {
                    atasi = (listem.Count - 1) / 2;

                }
                else
                {
                    atasi = (listem.Count) / 2;
                }
                if (listem.Count < atasi && listem[sıra].nüfusu > listem[atasi].nüfusu)
                {
                    Mahalle geçici = listem[atasi];
                    listem[atasi] = listem[sıra];
                    listem[sıra] = geçici;
                    YeriniDüzelt(atasi);
                }
                if (listem.Count > sıra * 2)
                {
                    if (listem[sıra * 2].nüfusu > listem[sıra].nüfusu)
                    {
                        Mahalle geçici = listem[sıra * 2];
                        listem[sıra * 2] = listem[sıra];
                        listem[sıra] = geçici;
                        YeriniDüzelt(sıra * 2);
                    }
                }
            }
        }
    }
}
