# 🛒 MultiShop: Microservices-Based E-Commerce Platform

This project represents the foundation of a modern e-commerce application built using the **Microservices** architectural pattern. It is primarily developed with .NET Core/ASP.NET Core technologies, where each functional domain (Product, Catalog, Order, etc.) is designed as an independent service.

## ✨ Key Features

* **Microservices Architecture:** Different business domains (Catalog, Order, etc.) are separated into independent, small services.
* **API Gateway:** **Ocelot** is used to provide a single entry point for all services.
* **Identity Management:** **IdentityServer** manages secure user authentication and authorization (OAuth 2.0 / OpenID Connect).
* **Multi-Frontend Support:** Designed to support different client applications such as an Admin Panel and a Customer Web Interface.
* **Container Support:** The infrastructure is prepared to allow the project to be easily managed using tools like Docker and Portainer.

## 🛠️ Technologies Used

The core technologies and tools underpinning this project include:

* **Backend:** .NET 6 / .NET 7 (or newer)
* **Architectural Pattern:** Microservices
* **API Management:** Ocelot
* **Security:** IdentityServer
* **Database:** SQL Server (or alternatives like PostgreSQL, MongoDB)
* **Containerization:** Docker, Portainer
* **Communication:** HTTP/REST APIs

## 📂 Project Structure

The project is organized into logical folders that reflect the microservices architecture:

| Folder Name | Description |
| :--- | :--- |
| `ApiGateway/` | Contains the Ocelot API Gateway, which serves as the single entry point for all microservices. |
| `IdentityServer/` | Hosts the IdentityServer project, managing authentication, authorization, and token generation. |
| `Services/` | The main folder containing all the core microservices (Catalog, Order, Basket, etc.) that implement the application's business logic. |
| `Frontends/` | Includes the client-side applications like the Web UI and Admin UI where users interact with the platform. |

## ⚙️ Setup and Running the Project

### Prerequisites

You will need the following tools to successfully run the project:

* [.NET SDK (6.0 or higher)](https://dotnet.microsoft.com/download)
* [Docker (optional, but highly recommended)](https://www.docker.com/get-started)
* An IDE (Visual Studio / VS Code)

### Steps

1.  **Clone the Repository:**
    ```bash
    git clone [https://github.com/onurabdulaji/MultiShop.git](https://github.com/onurabdulaji/MultiShop.git)
    cd MultiShop
    ```

2.  **Configure Connection Settings:**
    * Review and update the database connection strings, IdentityServer settings, and API URLs in the `appsettings.json` file for each microservice to match your local environment.

3.  **Run the Services:**

    #### **a. Running with Visual Studio (Debugging)**
    1.  Open the `MultiShop.sln` file in Visual Studio.
    2.  Right-click the solution in the Solution Explorer and select **"Set Startup Projects..."**.
    3.  Set all critical services (IdentityServer, API Gateway, and main microservices) to **"Start"** to launch them simultaneously.

    #### **b. Running with Docker (Recommended Method)**
    * If a `docker-compose.yml` file is present in the project folder, use it to start all services with a single command:
        ```bash
        docker-compose up -d
        ```

4.  **Access:**
    * You can access the application via the **API Gateway** address (usually `localhost:<Ocelot_Port>`) and the **Web UI** address.

## 🔑 License

This project is licensed under the **MIT License**. See the `LICENSE.txt` file for more details.

---





-*-*-*-*-*-*-**-*-**-*-*


# 🛒 MultiShop: Mikro Hizmetler Tabanlı E-Ticaret Platformu

Bu proje, modern bir e-ticaret uygulamasını **Mikro Hizmetler (Microservices)** mimarisiyle hayata geçirmeyi amaçlayan bir yapıdır. Temel olarak .NET Core/ASP.NET Core teknolojileri kullanılarak geliştirilmiştir ve her bir işlevsellik (Ürün, Katalog, Sipariş vb.) bağımsız bir hizmet olarak tasarlanmıştır.

## ✨ Temel Özellikler

* **Mikro Hizmet Mimarisi:** Uygulamanın farklı iş alanları (Katalog, Sipariş vb.) bağımsız hizmetlere ayrılmıştır.
* **API Gateway:** **Ocelot** kullanılarak tüm hizmetlere tek bir erişim noktası sağlanır.
* **Kimlik Yönetimi:** **IdentityServer** ile güvenli kullanıcı kimlik doğrulama ve yetkilendirme (OAuth 2.0 / OpenID Connect) işlemleri yönetilir.
* **Çoklu Ön Yüz Desteği:** Yönetim Paneli (Admin) ve Müşteri Arayüzü (Web) gibi farklı ön yüz uygulamalarını destekleyecek şekilde tasarlanmıştır.
* **Konteyner Desteği:** Projenin Docker ve Portainer gibi araçlarla kolayca yönetilebilmesi için altyapı mevcuttur.

## 🛠️ Teknolojiler

Bu projenin temelinde yer alan ana teknolojiler ve araçlar:

* **Arka Uç (Backend):** .NET 6 / .NET 7 (veya üzeri)
* **Mimari Desen:** Mikro Hizmetler
* **API Yönetimi:** Ocelot
* **Güvenlik:** IdentityServer
* **Veritabanı:** SQL Server (veya PostgreSQL, MongoDB gibi alternatifler)
* **Konteynerizasyon:** Docker, Portainer
* **İletişim:** HTTP/REST API'ler

## 📂 Proje Yapısı

Proje, mimariyi yansıtacak şekilde mantıksal klasörlere ayrılmıştır:

| Klasör Adı | Açıklama |
| :--- | :--- |
| `ApiGateway/` | Tüm mikro hizmetler için tek bir erişim noktası olan Ocelot API Gateway'i içerir. |
| `IdentityServer/` | Kimlik doğrulama, yetkilendirme ve token yönetimini sağlayan IdentityServer projesini barındırır. |
| `Services/` | Uygulamanın iş mantığını içeren tüm mikro hizmetlerin (Katalog, Sipariş, Sepet vb.) bulunduğu ana klasördür. |
| `Frontends/` | Kullanıcıların etkileşimde bulunduğu Web UI ve Admin UI gibi ön yüz (client) uygulamalarını içerir. |

## ⚙️ Kurulum ve Çalıştırma

### Ön Koşullar

Projenin başarıyla çalıştırılması için aşağıdaki araçlara ihtiyacınız vardır:

* [.NET SDK (6.0 veya üzeri)](https://dotnet.microsoft.com/download)
* [Docker (isteğe bağlı, ancak şiddetle önerilir)](https://www.docker.com/get-started)
* Bir IDE (Visual Studio / VS Code)

  ### Adımlar

1.  **Depoyu Klonlayın:**
    ```bash
    git clone [https://github.com/onurabdulaji/MultiShop.git](https://github.com/onurabdulaji/MultiShop.git)
    cd MultiShop
    ```

2.  **Bağlantı Ayarlarını Yapılandırın:**
    * Tüm mikro hizmetlerdeki `appsettings.json` dosyalarını kontrol ederek veritabanı bağlantı dizgilerini, IdentityServer ayarlarını ve API URL'lerini kendi ortamınıza göre güncelleyin.

3.  **Hizmetleri Çalıştırın:**

    #### **a. Visual Studio ile Çalıştırma (Hata Ayıklama Modu)**
    1.  `MultiShop.sln` dosyasını Visual Studio'da açın.
    2.  Çözüm Gezgini'nde çözüme sağ tıklayın ve **"Set Startup Projects..."** (Başlangıç Projelerini Ayarla) seçeneğini seçin.
    3.  Tüm kritik hizmetleri (IdentityServer, API Gateway ve ana mikro hizmetler) **"Start"** (Başlat) olarak işaretleyerek aynı anda çalışacak şekilde ayarlayın.

    #### **b. Docker ile Çalıştırma (Önerilen Yöntem)**
    * Proje klasöründe mevcut olabilecek `docker-compose.yml` dosyasını kullanarak tüm hizmetleri tek komutla ayağa kaldırın:
        ```bash
        docker-compose up -d
        ```

4.  **Erişim:**
    * Uygulamaya **API Gateway** adresi üzerinden (genellikle `localhost:<Ocelot_Port>`) ve **Web UI** adresi üzerinden erişim sağlayabilirsiniz.

## 🔑 Lisans

Bu proje **MIT Lisansı** altında lisanslanmıştır. Daha fazla bilgi için `LICENSE.txt` dosyasına bakınız.

---

  
