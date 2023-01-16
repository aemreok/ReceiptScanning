# ReceiptScanning

- Json'dan gelen listede her objenin boundingPoly.vertices[3].y'sini alma sebebim bu nokta her kelimenin sol alt noktasından başlama
noktasına denk geliyor ve karşılaştırma için bu noktaya ihtiyaç duydum.
- Kordinatlarda bu nokta aynı satırlardaki kelimeler için en fazla 9 fazla veya 9 eksik uzunluk farkına denk geldiğini fark ettim.
- Aynı satırlardaki Y eksenine denk gelen noktalar için `basedPointY` alanını oluşturup her objede aynı satırda
olanlar için eşit bir sayı olacak şekilde bir referans noktasına set ettim.
- Bu şekilde Y ekseninden sonra X ekseni için de `ThenBy` ile sıralama yaptım.
- Yazdırıken ise artık listem sıralı olduğu için aynı satırda olanları düzgün formatta yazdırabilmek için her objeyi sıradaki objenin `basedPointY`
değerine eşit olup olmadığını kontrol ettim ve ona göre bir string değer oluşturup `Console.WriteLine` ile yazdırdım.

