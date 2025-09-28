# K58KTP_Baitap.1_WEB
## TẠO SOLUTION GỒM CÁC PROJECT SAU:

    1.DLL đa năng, keyword: c# window library -> Class Library (.NET Framework) bắt buộc sử dụng .NET Framework 2.0: giải bài toán bất kỳ, độc lạ càng tốt, phải có dấu ấn cá nhân trong kết quả, biên dịch ra DLL. DLL độc lập vì nó ko nhập, ko xuất, nó nhận input truyền vào thuộc tính của nó, và trả về dữ liệu thông qua thuộc tính khác, hoặc thông qua giá trị trả về của hàm. Nó độc lập thì sẽ sử dụng được trên app dạng console (giao diện dòng lệnh - đen sì), cũng sử dụng được trên app desktop (dạng cửa sổ), và cũng sử dụng được trên web form (web chạy qua iis).
    2.Console app, bắt buộc sử dụng .NET Framework 2.0, sử dụng được DLL trên: nhập được input, gọi DLL, hiển thị kết quả, phải có dấu án cá nhân. keyword: c# window Console => Console App (.NET Framework), biên dịch ra EXE
    3.Windows Form Application, bắt buộc sử dụng .NET Framework 2.0**, sử dụng được DLL đa năng trên, kéo các control vào để có thể lấy đc input, gọi DLL truyền input để lấy đc kq, hiển thị kq ra window form, phải có dấu án cá nhân; keyword: c# window Desktop => Windows Form Application (.NET Framework), biên dịch ra EXE
    4.Web đơn giản, bắt buộc sử dụng .NET Framework 2.0, sử dụng web server là IIS, dùng file hosts để tự tạo domain, gắn domain này vào iis, file index.html có sử dụng html css js để xây dựng giao diện nhập được các input cho bài toán, dùng mã js để tiền xử lý dữ liệu, js để gửi lên backend. backend là api.aspx, trong code của api.aspx.cs thì lấy được các input mà js gửi lên, rồi sử dụng được DLL đa năng trên. kết quả gửi lại json cho client, js phía client sẽ nhận được json này hậu xử lý để thay đổi giao diện theo dữ liệu nhận dược, phải có dấu án cá nhân. keyword: c# window web => ASP.NET Web Application (.NET Framework) + tham khảo link chatgpt thầy gửi. project web này biên dịch ra DLL, phải kết hợp với IIS mới chạy được.
_____    
## BÀI LÀM
### BÀI TOÁN: Web quy đổi giá trị tiền tệ (VND, USD, EUR, JPY) 
<img width="1210" height="703" alt="image" src="https://github.com/user-attachments/assets/aa73d534-f7ba-4d40-a5a9-f70bb76ece6d" />

### Projects cần tạo:
- Class Library (.NET Framework 2.0)
- Console App (.NET Framework 2.0)
- Windows Form Application (.NET Framework 2.0)
- Web App — ASP.NET Web Application (.NET Framework 2.0)

### Các bước thực hiện
#### Bước 1: Tạo Solution
- Mở Visual Studio 2022 → File → New → Project → Blank Solution
- Name: CurrencySolution
- Location: chọn nơi lưu 
- Framework: bỏ trống, Blank Solution không cần Framework
- Tạo các Projects cần thiết

<img width="435" height="287" alt="image" src="https://github.com/user-attachments/assets/38c5e73f-c5c2-470b-8792-1356e62b613f" />

#### Bước 2: Tạo DLL đa năng – CurrencyConverter.dll
- Right click Solution → Add → New Project → Class Library (.NET Framework)
- Chọn .NET Framework 2.0
- Name: CurrencyDLL → OK
- Visual Studio tạo class Class1.cs. Đổi tên thành CurrencyConverter.cs
- Viết code DLL quy đổi tiền tệ vào:

<img width="1914" height="819" alt="image" src="https://github.com/user-attachments/assets/90817ff1-22e6-49ed-a0b8-3361b2bf622b" />

- Build → CurrencyDLL.dll
  
#### Bước 3: Tạo Console App – CurrencyConsoleApp
- Right click Solution → Add → New Project → Console App (.NET Framework)
- Chọn .NET Framework 2.0, Name: CurrencyConsoleApp
- Thêm Reference tới DLL:
  - Right click References → Add Reference → Browse → chọn CurrencyDLL.dll
- Viết code Console App

<img width="1897" height="872" alt="image" src="https://github.com/user-attachments/assets/92d26438-5436-4758-a131-124cb0df0bfc" />

- Run → thử nhập số, từ VND → USD, xem kết quả.

<img width="1849" height="780" alt="image" src="https://github.com/user-attachments/assets/8735b77f-b852-429a-9192-0ec40f693b4f" />

#### Bước 4: Tạo Windows Form – CurrencyWinFormApp

- Right click Solution → Add → New Project → Windows Forms App (.NET Framework)

- Chọn .NET Framework 2.0, Name: CurrencyWinFormApp

- Thêm Reference → CurrencyDLL.dll

-Thiết kế Form:

  - Cách 1: Dùng thao tác đồ họa kéo thả các thanh toolbox vào khung

  - Cách 2: Dùng code thay thế cho các file .cs để tự động tạo giao diện

- Bài này ta sẽ dùng code để xây dựng giao diện cho đề này:
  - Program.cs
<img width="1920" height="908" alt="image" src="https://github.com/user-attachments/assets/da40db24-111d-404c-b7d9-9ba4582d50b0" />

  - Form1.cs
<img width="1875" height="888" alt="image" src="https://github.com/user-attachments/assets/c004e41b-4b6e-415d-8fc9-d5c2f3dad74a" />

- Kết quả chạy thử:
<img width="1850" height="730" alt="image" src="https://github.com/user-attachments/assets/4f7985fb-a700-42d9-afa6-65986b8aacdc" />

#### Bước 5: Tạo Web App – CurrencyWebApp
- Right click Solution → Add → New Project → ASP.NET Web Application (.NET Framework)
- Chọn .NET Framework 2.0, Name: CurrencyWebApp
- Thêm Reference → CurrencyDLL.dll
- Thêm file index.html (giao diện đẹp, tiếng Việt):

<img width="1906" height="742" alt="image" src="https://github.com/user-attachments/assets/930f689f-6e66-4897-b98b-452075429531" />

- Thêm api.aspx + api.aspx.cs:  

<img width="1876" height="742" alt="image" src="https://github.com/user-attachments/assets/e799df62-d152-46d7-ad4a-b524d68d326f" />
 
#### Bước 6: Cấu hình Web trên IIS
- Open IIS Manager → Sites → Add Website
- Site name: CurrencyWeb
- Physical path: thư mục WebApp của bạn (CurrencyWebApp)
- Hostname: doitien.com
- Mở C:\Windows\System32\drivers\etc\hosts → thêm dòng:
  *127.0.0.1 doitien.com*
- Kết quả chạy trên localhost với tên miền là doitien.com:

<img width="1920" height="1030" alt="image" src="https://github.com/user-attachments/assets/28a9a9cd-d183-49d6-9124-3b805f493581" />

#### Bước 7: Kiểm tra và tinh chỉnh
- Console App → chạy → nhập số tiền + chọn tiền → kết quả đúng
- Windows Form → chạy → GUI đẹp + kết quả
- Web App → chạy trên IIS → giao diện đẹp + tiếng Việt + phản hồi nhanh  
