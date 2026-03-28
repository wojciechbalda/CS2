Instrukcja uruchomienia projektu:

1. Należy pobrać repozytorium przez kliknięcie przycisku "Download ZIP"
2. Należy rozpakować projekt z ZIPa
3. Otworzyć projekt w idea typu Rider
4. Uruchomić za pomoca odpowiedniego przycisku program


Opis projektu i krótkie uzasadnienie decyzji projektowych
Mój projekt składa się z takich klas jak:

- Device
- Monitor
- Laptop
- Phone
- User
- Student
- Employee
- Rental
- RentalService
- RaportService
- DeviceService
- UserService

Klasy zostały podzielone tak, aby były klasy serwisowe, które są odpowiedzialne za logikę biznesową.
Klasy, które nie są serwisowe to klasy domenowe, które skupiają się na przechowaniu danych.

Do klasy domenowej można zaliczyć:

- Device
- Phone
- Laptop
- Monitor
- User
- Employee
- Student
- Rental

Klasy takie jak Laptop, Monitor, Phone dziedziczą z klasy Device, ponieważ te wspomniane klasy dziedziczące mają część właściwości, które są identyczne, więc zaimplementowałem dziedziczenie, aby nie wpisywać powtarzających się wartości osobno do klasy Laptop, Monitor i Phone.
Na przykład każdy obiekt należący do klasy Lapto/Monitor/Phone ma nazwę oraz status dostępności pod kątem możliwości wypożyczenia.

Podobnie jest w przypadku klasy Employee i Student gdzie obie klasy dziedziczą po Userze (klasie abstrakcyjnej) ze względu na podobne właśności. Zarówno student jak i pracownik mają imię i nazwisko. 
Dodatkowo ze względu na to, że student i pracownik mają limity wypożyczeń to trzeba było znaleźć rozwiązanie na temat tego jak dostarczyć informacje o limicie wypożyczeń. Rozwiązaniem właśnie była klasa abstrakcyjna, która ma odpowiednią metodę abstrakcyjną. Pozawala to wymusić implementację odpowiedniej metody czyli gwarantuje, że każda klasa dziedzicząca będzie miała metodę zwracająca maksymalny limit wypożyczeń.


W celu zapewnienia koherezji każda klasa skupia się tylko na jednym aspekcie:

- RentalService - zajmuje się tylko obsługą wypożyczeń 
- DeviceService - zarządza sprzętem w wypożyczalni
- UserService - zajmuje się obsługą związaną z Userami
- ReportService - generuje raporty

Pozostałe klasy przechowują odpowiednio dane dla swoich obiektów np. User przechowuje dane, które są ważne dla użytkownika itd.

Dzięki takiemu podziałowi klas jest zachowana czytelność kodu w większym stopniu, gdyby jej nie było. Także zwiększa się łatwość utrzymania.


Dużo klas także korzysta z kompozycji. Na przykład klasa RentalService zawiera obiekty klasy Rental. Zostało to zrobione w celu otrzymania koherezji. Przy takim podziale było możliwe zrobienie klasy, która odpowiada za obsługę wypożyczeń i innej klasy, która odpowiada za przechowywanie informacji o wypożyczeniu.