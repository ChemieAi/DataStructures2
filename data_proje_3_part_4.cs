using System;
using System.Collections.Generic;

namespace data_proje_3_part_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sayilar = new List<int>();
            sayilar.Add(17);
            sayilar.Add(15);
            sayilar.Add(20);
            sayilar.Add(10);
            sayilar.Add(6);
            sayilar.Add(9);
            sayilar.Add(25);
            BubbleSort(sayilar);
            for (int i = 0; i < sayilar.Count; i++)
            {
                Console.WriteLine(sayilar[i]);
            }

        }
        public static void BubbleSort(List<int> liste)
        { //Küçükten büyüğe sıralayan bubblesort, en büyüğü sola taşıyor. Her while a girdiğinde listenin en sonuna kesin olarak en büyüğü taşıyor bu yüzden.
            if (liste.Count > 1)  // Sıralanması gereken kısmı 1 azaltarak hız kazandırdık ama yine de bu yazmasının kolaylığı haricinde; insertion sort veya quick sort olsun, bunlara karşı bir avantaj sağlamıyor.
            {   //Mesela quick  sortun yazması zordur ama yüksek elemanlı (+30 elemanlı) veri kümelerinde bubble sorta göre baya zaman kazandırır, ya da insertion sort az karşılaştırma yapar. 
                bool islemYapıldıMı = true;// Zaman karmaşıklığı ilk turda n-1 karşılaştırma sonrasında n-2, n-3 ... tarzı gittiği için n^2 kare gelir. 
                int sıralanmasıGerekenKısım = liste.Count;
                while (islemYapıldıMı)
                {
                    islemYapıldıMı = false;
                    int arka;
                    int şuAnKi;
                    int tutucu;
                    for (int i = 1; i < sıralanmasıGerekenKısım; i++)
                    {
                        arka = liste[i - 1];
                        şuAnKi = liste[i];
                        if (arka > şuAnKi)
                        {
                            liste[i] = arka;
                            liste[i - 1] = şuAnKi;
                            islemYapıldıMı = true;
                        }
                    }
                    sıralanmasıGerekenKısım = sıralanmasıGerekenKısım - 1;
                }
            }
        }
    }
}
