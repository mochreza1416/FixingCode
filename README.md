# FixingCode
1. menggunakan operator kondisional null
2. menggunakan Tuple untuk mengembalikan dua nilai (Path and Name)
3. _os adalah private field yang menyimpan nilai sistem operasi.
Properti Os adalah properti publik dengan private setter, yang memungkinkannya dimodifikasi hanya dalam kelas Laptop.
Metode SetOs adalah private method yang menetapkan nilai bidang _os. Ini dapat mencakup logika atau validasi tambahan sebelum menetapkan nilai.
Ini akan mencetak "macOs" dengan benar karena Os diakses melalui instance kelas Laptop.
4. Dalam kode yang diberikan, terdapat contoh potensi memory leak karena terus menambahkan objek ke daftar tanpa menghapusnya. Untuk mencegah memory leak, penting untuk mengelola referensi objek dengan benar dan menghapus objek dari memori saat tidak diperlukan lagi.
5. Dalam kode yang disediakan, terdapat contoh potensi memory leak karena event handlers tidak dilepaskan ketika objek EventSubscriber tidak lagi diperlukan. Untuk mencegah memory leak dalam skenario ini, harus melepaskan event handlers saat tidak diperlukan lagi, biasanya saat objek EventSubscriber dibuang.
6. Terdapat contoh potensi memory leak karena pembuatan grafik objek besar (TreeNode) tanpa pembuangan atau pembersihan yang benar. Untuk mencegah memory leak dalam skenario ini, harus memastikan bahwa objek dibuang dengan benar saat tidak diperlukan lagi, terutama saat menangani grafik objek besar.Salah satu pendekatan untuk mencegah memory leak dalam skenario ini adalah dengan mengimplementasikan antarmuka IDisposable di kelas TreeNode dan secara rekursif membuang node anak ketika sebuah node dibuang.
7. Ada potensi masalah dengan cache yang tidak tepat, karena kode tersebut mengisi cache dengan objek dalam jumlah besar tanpa mekanisme apa pun untuk membatasi ukuran cache atau menghapus objek dari cache saat tidak diperlukan lagi. Hal ini dapat menyebabkan konsumsi memori berlebihan dan berpotensi menurunkan kinerja.
Untuk mengatasi masalah ini, dapat menerapkan mekanisme untuk membatasi ukuran cache dan mengeluarkan objek ketika cache mencapai batasnya. Salah satu pendekatan yang umum adalah dengan menggunakan kebijakan penggusuran yang Paling Terakhir Digunakan (LRU), yang mana objek yang paling jarang diakses akan dihapus dari cache ketika mencapai ukuran maksimumnya.
