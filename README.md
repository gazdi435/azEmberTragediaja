# Pizza Rendelő Alkalmazás

## Projekt Áttekintés

Ez a projekt egy c# pizza rendelési alkalmazás, amelyben a felhasználók egy felhasználói, böngészhetnek a pizzák között, kosárba tehetik őket, majd leadhatják a rendelésüket. Illetve pizzázók követhetik raktáraikat és étlapjukat. A rendszer több rétegre épül: egy felhasználói rétegre, egy adatbázis rétegre, valamint egy karbantartói rétegre, amely jelenleg fejlesztés alatt áll.

## Fejlesztők és munkafelosztás
- ### [Majoros Péter](https://github.com/Majoros-Peter "Majka github profilja"): az adatbázis és az sql lekérdezések, design
- ### [Győrfi Marcell](https://github.com/gyorfimarcell "Győrfi Marcell github profilja"): a karbantartói oldal és a rendelés oldal
- ### [Gazdag Zsolt](www.github.com/gazdi435 "Én jómagam nekem számomra részemre"): bejelentkezés és regisztrációs oldal

## Rendszer Architektúra

Az alkalmazás három rétegből áll:
1. **Felhasználói oldal**:
   - A felhasználó bejelentkezhet vagy új fiókot hozhat létre.
   - A felhasználó böngészhet a rendelhető pizzák között.
   - A pizzákhoz hozzávalókat láthat, és kiválaszthatja azokat.
   - A felhasználó kosárhoz adhatja a pizzákat és megrendelheti őket.
   - A leadott rendelések bekerülnek az adatbázisba.

2. **Adatbázis oldal**:
   - Az adatbázis 6 táblát tartalmaz:
     - Felhasználók: A regisztrált felhasználók adatai.
     - Rendelések: A leadott rendelések.
     - Pizzák: A rendelhető pizzák listája.
     - Hozzávalók: A pizzákhoz tartozó alapanyagok listája.
     - Feltétek: A rendelhető pizzákra tehető különböző feltétek.
     - RendelésElemei: A rendelésekhez tartozó pizzák és azok részletei.

3. **Karbantartói oldal**:
   - A karbantartói oldal lehetőséget biztosít az adminisztrátorok számára a raktárkészletek figyelésére.
   - A pizzák hozzáadhatók vagy törölhetők az étlapról.
   - A hozzávalók és feltétek módosíthatók.

## Technológiai Környezet

- **Backend**: c# WPF
- **Adatbázis**: SQL (SQL Server vagy más SQL-kompatibilis adatbázis)

## Telepítés és Beállítás

### Előfeltételek
- **.NET SDK** (ajánlott a legújabb verzió)
- **SQL Server** (vagy bármilyen kompatibilis SQL adatbázis)

### Lépések

1. Klónozd a repozitóriumot:
   ```bash
   git clone https://github.com/gazdi435/azEmberTragediaja.git
   ```
   
2. Nyisd meg a projektet a Visual Studio-ban:
   ```bash
   cd azEmberTragediaja
   open azEmberTragediaja.sln
   ```

3. Állítsd be az adatbázist:
   - Hozz létre egy SQL adatbázist, és frissítsd a kapcsolati karakterláncot a konfigurációs fájlban.
   - Futtasd az adatbázis migrációkat vagy a mellékelt szkripteket a szükséges táblák létrehozásához.

4. Indítsd el az alkalmazást:
   - A Visual Studio-ban építsd fel és futtasd az alkalmazást.

## Használati Útmutató

### Felhasználói Műveletek

- **Regisztráció és Bejelentkezés**: A felhasználó regisztrálhat új fiókot vagy bejelentkezhet meglévő hitelesítő adataival.
- **Pizza Böngészés és Rendelés**: A felhasználó böngészheti a pizzák listáját, megtekintheti a hozzávalókat, kosárba helyezheti a kiválasztott pizzákat, majd leadhatja a rendelést.
- **Rendelés**: A rendelés leadása után az adatok bekerülnek az adatbázisba, és a felhasználó értesítést kap a rendelés sikeres feldolgozásáról.

### Felhasználói felület
<img src="/readmeImages/regist.png" alt="drawing" width="500"/>
<img src="/readmeImages/login.png" alt="drawing" width="500"/>
<img src="/readmeImages/main.png" alt="drawing" width="500"/>

-  1 Könnyedén kikeresheti a megvásárólni kívánt pizzákat.
-  2 Itt láthatja a pizza alapanyagait.
-  3 Kosarából könnyedén eltávolíthat illetve hozzáadhat pizzákat.
-  4 Kiválaszthatja az egyes pizzák mennyiségét.

### Karbantartói Funkciók (Fejlesztés alatt)

- **Pizzák Kezelése**: Pizzák hozzáadása és eltávolítása a rendelhető pizzák listájáról.
- **Hozzávalók és Feltétek Kezelése**: A pizzákhoz tartozó hozzávalók és feltétek módosítása.
- **Raktárkészletek Figyelése**: Az adminisztrátorok számára lehetőség nyílik a raktárkészletek figyelemmel követésére.

## Fejlesztés és Karbantartás 

- **Rendszeres Frissítések**: A rendszer karbantartásakor ügyelj a verziók kezelésére és az adatbázis frissítésére.
- **Biztonság**: Biztosítsd, hogy az adatbázisban tárolt érzékeny adatok (pl. jelszavak) titkosítva legyenek.

## További Fejlesztési Lehetőségek

- **Felhasználói Felület Javítása**: További funkciók hozzáadása, például rendelések nyomon követése.
- **Karbantartói Rendszer Bővítése**: A raktárkezelés és az adminisztrációs funkciók további finomítása és bővítése.

_Ez a dokumentáció egy részletes áttekintést ad a projektről, annak felépítéséről, valamint telepítési és használati útmutatót nyújt a fejlesztők és felhasználók számára._
