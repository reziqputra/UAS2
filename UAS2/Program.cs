using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_kasir //membuat namespace untuk menamakan program
{
    class Program  //membuat class program untuk memasukkan fungsi dan variabel
    {
        static void Main(string[] args) //Suatu method void adalah suatu method yang hanya menjalankan sekumpulan perintah dan tidak menghasilkan suatu nilai (Tetapi masih dapat menampilkan sesuatu ke layar).
        {
            Console.WriteLine("\t\t=============================================================================\n");//menampilan teks dalam suatu baris
            Console.WriteLine("\t\t                    program pembelian makanan dan minuman");
            Console.WriteLine("\t\t                                  Comma cafe ");
            Console.WriteLine("\t\t      jalan. godean NO. 666, Candran, kec. Sidoarum, kabupaten Sleman  ");
            Console.WriteLine("                                     081215932697 ");
            Console.WriteLine("MINUMAN\n");
            Console.WriteLine(" 1. Ice tea          : Rp. 8000");
            Console.WriteLine(" 2. Thai tea         : Rp. 15000");
            Console.WriteLine(" 3. Coffe milk       : Rp. 16000");
            Console.WriteLine(" 4. Read valvet      : Rp. 25000\n\n");

            Console.WriteLine("MAKANAN\n");
            Console.WriteLine(" 1. rice bowl        : Rp. 17000");
            Console.WriteLine(" 2. fried chicken    : Rp. 12000");
            Console.WriteLine(" 3. nasi goreng      : Rp. 18000");
            Console.WriteLine(" 4. indomie goreng   : Rp. 5000\n\n");

            Console.WriteLine("SNACK\n");
            Console.WriteLine(" 1. mendoan          : Rp. 10000");
            Console.WriteLine(" 2. dimsum           : Rp. 10000");
            Console.WriteLine(" 3. nugget           : Rp. 15000");
            Console.WriteLine(" 4. ketang goreng    : Rp. 11000");

            int jumlah; //membuat tipe data int untuk jumlah
            //Looping dengan menginput jumlah barang menggunakan kondisi do while
            do
            {
                Console.WriteLine("masukan jumlah barang");
                jumlah = int.Parse(Console.ReadLine());
            }
            while (jumlah <= 0 || jumlah > 100);
            //mendeklarasi atau mendefinisikan variabel data
            string[] nama = new string[jumlah]; //membuat tipe data string untuk nama
            int[] harga = new int[jumlah]; //membuat tipe data int untuk harga
            int total = 0; //membuat tipe data int untuk total
            int bayar, kembali; //membuat tipe data int untuk bayar dan kembalian
            
            //Looping menggunakan  kombinasi array
            for (int i = 0; i < jumlah; i++)
            {
                do
                {
                    //menampilkan input Nama barang
                    Console.WriteLine("\nmasukan nama barang ke-" + (i + 1));
                    nama[i] = Console.ReadLine(); //untuk membaca teks yang kita ketik dalam satu baris (teks).
                }
                //user harus menginput nama barang diatas 0 karakter sampai dengan 20 karakter
                while (nama[i].Length <= 0 || nama[i].Length >= 20);

                do
                {
                    //menampilkan input harga
                    Console.WriteLine("masukan harga barang ke-" + (i + 1));
                    harga[i] = int.Parse(Console.ReadLine());
                }
                //user harus menginput harga barang minimal 6000 sampai 100000
                while (harga[i] <= 5000 || harga[i] >= 100000);
            }
            //membuat string nama kasir, nama pembeli, tanggal dan jam
            string namak;
            string namap;
            string tanggal;
            string jam;
            //menginput data nama kasir, nama pelanggan, tanggal dan jam
            Console.Write("\n\nnama kasir : ");
            namak = Console.ReadLine();

            Console.Write("nama pembeli : ");
            namap = Console.ReadLine();

            tanggal = DateTime.Now.ToString("dd/MM/yyy");

            jam = DateTime.Now.ToString("hh:mm:ss");

            //memunculkan data nama kasir, nama pelanggan, tanggal dan jam
            Console.Write("tanggal transaksi : " + tanggal);
            Console.Write("\njam transakasi : " + jam);
            Console.WriteLine("\n\nbarang yang dibeli");
            Console.WriteLine("==========================================================");
            for (int i = 0; i < jumlah; i++)
            {
                Console.WriteLine((i + 1) + ". " + nama[i] + "     " + harga[i]);
            }

            foreach (int i in harga)
            {
                total += i;
            }

            Console.WriteLine("=================================");
            Console.WriteLine("total          " + total);

            do
            {
                Console.Write("\n\n uang yang di bayar : ");
                bayar = int.Parse(Console.ReadLine());

                kembali = bayar - total;

                //kondisi apabila uang yang dibayarkan kurang
                if (bayar < total)
                {
                    Console.WriteLine("maaf, uang anda kurang !!");
                    Console.WriteLine("-------------------------");
                }
                //kondisi apabila uang yang dibayarkan pas atau lebih
                else //menampilkan uang kembalian
                {
                    Console.WriteLine("\n\n uang kembalian anda Rp. " + kembali + ",00");
                }
            }
            while (bayar < total);
            //mencetak nota dengan streamwritter
            using (StreamWriter sw = new StreamWriter(@"D:\Kuliah\Nota.txt"))
            {
                sw.WriteLine("+==================================================+");
                sw.WriteLine("+============= Nota Pembayaran ====================+");
                sw.WriteLine("+==================================================+");
                sw.WriteLine("             Nama Barang Yang Dibeli                ");
                for (int i = 0; i < jumlah; i++)
                {
                    sw.WriteLine((i + 1) + ". " + nama[i] + "   " + harga[i]);
                }
                sw.WriteLine("+==================================================+");
                sw.WriteLine("Total Harga       : Rp" + total);
                sw.WriteLine("Tunai             : Rp" + bayar);
                sw.WriteLine("Kembalian         : Rp" + kembali);
                sw.WriteLine("\n");
                //menampilkan nama pelanggan
                sw.WriteLine("Nama Pelanggan: {0}", namap.ToString());
                //menampilkan tanggal dan jam
                sw.WriteLine("tanggal transaksi : " + tanggal);
                sw.WriteLine("\njam transakasi : " + jam);
                sw.WriteLine("+==================================================+");
                sw.WriteLine("Nama Kasir : " + namak);
                sw.WriteLine("          selamat menikmati hidangan");
                Console.WriteLine("======== Nota telah di print ==================");

            }
           
            Console.ReadLine();

        }
    }
}