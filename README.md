# Pizza Rendelő Alkalmazás

## Projekt Áttekintés

Ez a projekt egy webalapú pizza rendelési rendszer, amelyben a felhasználók regisztrálhatnak, bejelentkezhetnek és pizzát rendelhetnek. Az alkalmazás **.NET C#** nyelven készült, a háttérrendszerhez, és **SQL** adatbázist használ az adatok tárolásához. A rendszer egy felhasználói rétegből és egy adatbázis rétegből áll, amelyek egymáshoz kapcsolódnak.

## Célok és Feladatok

- Lehetővé teszi a felhasználók számára, hogy regisztráljanak vagy bejelentkezzenek meglévő fiókkal.
- Lehetővé teszi a felhasználók számára a pizzák böngészését, kiválasztását és rendelését.
- Biztonságos és hatékony módon kezeli és tárolja a felhasználói adatokat és rendelési információkat.

## Rendszer Architektúra

### Rétegek

1. **Felhasználói réteg**: 
   - Felelős a felhasználói interakciók kezeléséért, mint például a regisztráció, bejelentkezés és pizza rendelés.
   - A felhasználók bejelentkezhetnek, fiókot hozhatnak létre, és böngészhetnek a rendelkezésre álló pizzák között.

2. **Adatbázis réteg**: 
   - Kezeli a felhasználói adatokat és rendeléseket.
   - **SQL** alapú adatbázist használ a felhasználói hitelesítési adatok, pizzainformációk és rendeléstörténet tárolására.

### Technológiai Környezet

- **Backend**: .NET C# 
- **Adatbázis**: SQL (SQL Server vagy más SQL-kompatibilis adatbázis)

## Telepítés és Beállítás

### Előfeltételek
- **.NET SDK** (ajánlott a legújabb verzió)
- **SQL Server** (vagy bármilyen kompatibilis SQL adatbázis)

### Lépések

1. Klónozd a repozitóriumot:
   ```bash
   git clone https://github.com/your-repository/pizza-ordering-app.git
Nyisd meg a megoldást a Visual Studio-ban:

bash
Kód másolása
cd pizza-ordering-app
open PizzaOrderingApp.sln
Állítsd be az adatbázist:

Hozz létre egy SQL adatbázist, és frissítsd a kapcsolati karakterláncot a konfigurációs fájlban.
Futtasd az adatbázis migrációkat vagy a mellékelt szkripteket a szükséges táblák létrehozásához.
Indítsd el az alkalmazást:

A Visual Studio-ban építsd fel és futtasd az alkalmazást a webes alkalmazás indításához.
Használati Útmutató
Felhasználói Regisztráció és Bejelentkezés
Regisztráció: Látogass el a regisztrációs oldalra egy fiók létrehozásához.
Bejelentkezés: Használd a bejelentkezési oldalt a hitelesítő adatokkal való belépéshez.
Pizza Rendelés
Bejelentkezés után a felhasználók böngészhetnek a rendelkezésre álló pizzák között, testre szabhatják rendelésüket, és leadhatják azt.
A rendszer tárolja a felhasználó rendeléstörténetét későbbi hivatkozás céljából.
Telepítés
Háttérrendszer Telepítése: A .NET alkalmazást webkiszolgálón (pl. IIS) vagy felhőben (pl. Azure, AWS) kell üzemeltetni.
Adatbázis Telepítése: Az SQL adatbázist felhőszolgáltatáson (pl. Azure SQL Database) vagy helyi szerveren kell üzemeltetni.
Hibakeresés
Adatbázis Kapcsolati Problémák: Ellenőrizd, hogy a konfigurációban szereplő kapcsolati karakterlánc megegyezik az adatbázis beállításaival.
Bejelentkezési Hibák: Győződj meg arról, hogy a felhasználói hitelesítési adatok helyesen vannak tárolva az adatbázisban, és a jelszóhash-elés megfelelően működik.
Karbantartás és Frissítések
Adatbázis Frissítések: Ha a séma változik, futtasd az új migrációkat.
Hibajavítások: Rendszeresen ellenőrizd a naplókat futásidőben fellépő hibák esetén, és oldd meg a problémákat.
Biztonsági Szempontok
Hitelesítés: A felhasználói hitelesítést biztonságos módszerekkel kezeljük.
Adattitkosítás: Az érzékeny adatokat, beleértve a jelszavakat, megfelelő titkosítási algoritmusokkal védjük.

