using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VeriYapilariOdev_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var acil = new Acil();
            var orta = new Orta();
            var düşük = new Düşük();

            while (true)
            {
                Console.WriteLine("\nLütfen seçim yapınız: Acil işlemler (1), Orta seviyeli işlemler (2), Düşük seviyeli işlemler (3), Sıradaki müşteriyi göster (4), Çıkış (0)");
                int islemSecimi = int.Parse(Console.ReadLine());

                if (islemSecimi == 0) break;

                IKuyruk secilenKuyruk = null;  // secilenKuyruk başta null olarak ayarlandı.

                if (islemSecimi == 1)
                {
                    secilenKuyruk = acil;
                }
                else if (islemSecimi == 2)
                {
                    secilenKuyruk = orta;
                }
                else if (islemSecimi == 3)
                {
                    secilenKuyruk = düşük;
                }

                if (secilenKuyruk != null)
                {
                    yapılanİslem(secilenKuyruk, acil, orta, düşük);
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim.");
                }
            }
        }
        static void yapılanİslem(IKuyruk veriYapisi, IKuyruk acil, IKuyruk orta, IKuyruk düşük)
        {
            
            int secim = menu();
            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        Console.Write("Adınız: ");
                        string ad = Console.ReadLine();
                        Console.Write("Soyadınız: ");
                        string soyad = Console.ReadLine();
                        veriYapisi.ekle(new Müsteri(ad, soyad));
                        break;

                    case 0: break;

                    case 2:
                        // Öncelik sırasına göre sıradaki müşteriyi gösterme
                        Müsteri siradakiMusteri = acil.Peek() ?? orta.Peek() ?? düşük.Peek();
                        if (siradakiMusteri != null)
                        {
                            Console.WriteLine("Sıradaki müşteri: " + siradakiMusteri);
                        }
                        else
                        {
                            Console.WriteLine("Kuyruklar boş.");
                        }
                        break;

                }
                secim = menu();
            }
        }

        private static int menu()
        {
            Console.WriteLine("\n1-Giriş yapma");
            Console.WriteLine("0 Çıkış");
            Console.WriteLine("2- Sıradaki müşteri");
            Console.Write("Seçiniz: ");
            
            return int.Parse(Console.ReadLine());
        }

        interface IKuyruk
        {
            void ekle(Müsteri musteri);
            Müsteri Peek();
            Müsteri Dequeue();
        }

        class Node
        {
            public Müsteri Data { get; set; }
            public Node Next { get; set; }

            public Node(Müsteri data)
            {
                Data = data;
                Next = null;
            }
        }

        // Kuyruk yapısı sınıfı
        class Müsteri
        {
            public string Adi;
            public string SoyAdi;


            public Müsteri(string ad, string soyad)
            {
                Adi = ad;
                SoyAdi = soyad;

            }
            public override string ToString()
            {
                return $": Ad: {Adi}, Soyad: {SoyAdi}";
            }

        }
       

        class Acil:IKuyruk
        {
            private Node front; // kuyruğun başındaki elemanı tutacak
            private Node rear; // kuyruğun sonundaki elemanı tutacak




            public void ekle(Müsteri must)
            {
                Node eleman = new Node(must);
                if (front == null)
                {
                    front = rear = eleman;
                    Console.WriteLine("Acil işlemlere giriş yapıldı lütfen bekleyiniz");
                }
                else
                {
                    rear.Next = eleman;
                    rear = eleman;
                    Console.WriteLine("Acil işlemlere giriş yapıldı lütfen bekleyiniz");
                }
            }

            public Müsteri Peek()
            {
                return front != null ? front.Data : null;
            }
            public Müsteri Dequeue()
            {
                if (front == null) return null;
                Müsteri temp = front.Data;
                front = front.Next;
                return temp;
            }
        }


        class Orta : IKuyruk
        {
            private Node front; // kuyruğun başındaki elemanı tutacak
            private Node rear; // kuyruğun sonundaki elemanı tutacak




            public void ekle(Müsteri must)
            {
                Node eleman = new Node(must);
                if (front == null)
                {
                    front = rear = eleman;
                    Console.WriteLine("Orta işlemlere giriş yapıldı lütfen bekleyiniz");
                }
                else
                {
                    rear.Next = eleman;
                    rear = eleman;
                    Console.WriteLine("Orta işlemlere giriş yapıldı lütfen bekleyiniz");
                }

            }
            public Müsteri Peek()
            {
                return front != null ? front.Data : null;
            }
            public Müsteri Dequeue()
            {
                if (front == null) return null;
                Müsteri temp = front.Data;
                front = front.Next;
                return temp;
            }

        }

        class Düşük: IKuyruk
        {
            private Node front; // kuyruğun başındaki elemanı tutacak
            private Node rear; // kuyruğun sonundaki elemanı tutacak




            public void ekle(Müsteri must)
            {
                Node eleman = new Node(must);
                if (front == null)
                {
                    front = rear = eleman;
                    Console.WriteLine("Düşük işlemlere giriş yapıldı lütfen bekleyiniz");
                }
                else
                {
                    rear.Next = eleman;
                    rear = eleman;
                    Console.WriteLine("Düşük işlemlere giriş yapıldı lütfen bekleyiniz");
                }
            }
            public Müsteri Peek()
            {
                return front != null ? front.Data : null;
            }
            public Müsteri Dequeue()
            {
                if (front == null) return null;
                Müsteri temp = front.Data;
                front = front.Next;
                return temp;
            }



        }











    }
}
