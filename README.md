# ElGamal Encryption
## Giới thiệu
Đây là chương trình triển khai thuật toán mã hóa ElGamal trên Windows Forms (C#). Chương trình cho phép mã hóa và giải mã văn bản sử dụng khóa công khai và khóa bí mật dựa trên bài toán logarit rời rạc.

## Tính năng
- Tạo khóa công khai (p, a, y) và khóa bí mật (x).
- Mã hóa văn bản rõ thành văn bản mã.
- Giải mã văn bản mã về văn bản rõ.
- Tự động tạo giá trị ngẫu nhiên cho k.
- Xóa dữ liệu để nhập lại từ đầu.
![Image](https://github.com/user-attachments/assets/17ffc8fe-4a06-4422-90e4-81837a394f8f)
## Hướng dẫn sử dụng
1. Nhập các giá trị:
  - p: Số nguyên tố.
  - a: Nguyên tố cơ bản (generator).
  - x: Khóa bí mật.
2. Nhấn "Tạo khóa" để sinh khóa công khai và bí mật.
3. Nhập văn bản rõ vào ô "Bản rõ", nhấn "Mã hóa" để tạo văn bản mã.
4. Nhập văn bản mã vào ô "Bản mã", nhấn "Giải mã" để lấy lại văn bản rõ.
5. Sử dụng "Tự động" để tạo giá trị k ngẫu nhiên hoặc "Làm lại" để xóa toàn bộ dữ liệu.

## Yêu cầu
- .NET Framework.
- Visual Studio để biên dịch và chạy mã nguồn.
## Lưu ý
- Đảm bảo nhập đầy đủ các tham số (p, a, x, k) trước khi thực hiện mã hóa/giải mã.
- Chương trình sử dụng hàm mod để tính lũy thừa mô-đun và modInverse để tìm nghịch đảo mô-đun.
