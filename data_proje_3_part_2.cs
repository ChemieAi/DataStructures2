using System;
using System.Collections;
namespace data_proje_3_part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable MahallelerVeNufusları = new Hashtable();
            string[] mahalleAdları = { "MERİÇ", "KOŞUKAVAK", "TUNA", "BİRLİK", "SERİNTEPE", "ÇAMKULE", "MERKEZ", "YILDIRIM BEYAZIT", "ÜMİT", "ÇINAR" };
            MahallelerVeNufusları.Add(mahalleAdları[0], 8394);
            MahallelerVeNufusları.Add(mahalleAdları[1], 7916);
            MahallelerVeNufusları.Add(mahalleAdları[2], 7607);
            MahallelerVeNufusları.Add(mahalleAdları[3], 6949);
            MahallelerVeNufusları.Add(mahalleAdları[4], 6905);
            MahallelerVeNufusları.Add(mahalleAdları[5], 6709);
            MahallelerVeNufusları.Add(mahalleAdları[6], 6341);
            MahallelerVeNufusları.Add(mahalleAdları[7], 6192);
            MahallelerVeNufusları.Add(mahalleAdları[8], 4593);
            MahallelerVeNufusları.Add(mahalleAdları[9], 4287);
            Console.WriteLine("          Önce olduğu gibi yazdırıyoruz: ");
            for (int i = 0; i < mahalleAdları.Length; i++)
            {
                Console.WriteLine("Mahallenin Adı: " + mahalleAdları[i] + "\n" +
                                  "Mahallenin Nüfusu: " + MahallelerVeNufusları[mahalleAdları[i]] + "\n");
            }

            string verilenBaşHarf = "M"; //Şimdi verilen harfle başlayan keylerin valuesine 1 eklenecek.
            for (int i = 0; i < 10; i++)
            {
                string şuAnkiMahalle = mahalleAdları[i];

                if (şuAnkiMahalle.StartsWith(verilenBaşHarf))
                {
                    int a = (int)MahallelerVeNufusları[mahalleAdları[i]];
                    a = a + 1;
                    MahallelerVeNufusları[mahalleAdları[i]] = a;
                }
            } //Eklendi, şimdi yazdırılacak.
            Console.WriteLine(" Sonra ise " + verilenBaşHarf + " baş harfine sahiplerin nüfusunu 1 arttırıp yazdırıyoruz: ");
            for (int i = 0; i < mahalleAdları.Length; i++)
            {
                Console.WriteLine("Mahallenin Adı: " + (string)mahalleAdları[i] + "\n" +
                                  "Mahallenin Nüfusu: " + MahallelerVeNufusları[mahalleAdları[i]] + "\n\n");
            }
        }
    }
}
