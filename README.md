# Setup

```shell
dotnet tool install -g dotnet-reportgenerator-globaltool
dotnet tool install -g coverlet.console
```

# Run test

```shell
dotnet test  --collect:"XPlat Code Coverage" --results-directory=TestResults
```

# Create code coverage report

```shell
reportgenerator -reports:./TestResults/**/*.xml -targetdir:./TestCoverageReport
```

# Run app

```shell
# Normal case
dotnet run sum 15 5
dotnet run sub 15 5
dotnet run mul 15 5
dotnet run div 15 5
dotnet run sumf 1.2 1.3
dotnet run mkdir test

# Bug
dotnet run sum 2147483647 1
dotnet run sub -2147483648 1
dotnet run mul 2147483647 2
dotnet run div 2147483647 0
dotnet run sumf 1.1 1.2
dotnet run mkdir test:d
```

# nab-ut
Normal case, abnormal case and boundary in unit test

Trong unit test, các khái niệm **normal case**, **abnormal case**, và **boundary case** rất quan trọng để đảm bảo rằng mã của bạn hoạt động đúng trong mọi tình huống. Dưới đây là giải thích chi tiết về từng khái niệm:

1. **Normal Case (Trường hợp bình thường)**:
   - Đây là các trường hợp kiểm thử mà bạn mong đợi mã của mình sẽ hoạt động đúng như dự kiến với các đầu vào hợp lệ và phổ biến.
   - Ví dụ: Kiểm tra hàm cộng hai số nguyên dương.

     ```csharp
     [Fact]
     public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
     {
         int result = Add(2, 3);
         Assert.Equal(5, result);
     }
     ```

2. **Abnormal Case (Trường hợp bất thường)**:
   - Đây là các trường hợp kiểm thử mà bạn kiểm tra mã của mình với các đầu vào không hợp lệ hoặc không mong đợi để đảm bảo rằng mã xử lý chúng một cách đúng đắn.
   - Ví dụ: Kiểm tra hàm chia cho số 0.

     ```csharp
     [Fact]
     public void Divide_ByZero_ThrowsException()
     {
         Assert.Throws<DivideByZeroException>(() => Divide(10, 0));
     }
     ```

3. **Boundary Case (Trường hợp biên)**:
   - Đây là các trường hợp kiểm thử mà bạn kiểm tra mã của mình với các giá trị ở ranh giới của các đầu vào hợp lệ để đảm bảo rằng mã xử lý chúng một cách đúng đắn.
   - Ví dụ: Kiểm tra hàm tính tổng với các giá trị cực đại và cực tiểu của kiểu dữ liệu.

     ```csharp
     [Fact]
     public void Add_MaxIntValues_ReturnsCorrectSum()
     {
         int result = Add(int.MaxValue, 0);
         Assert.Equal(int.MaxValue, result);
     }

     [Fact]
     public void Add_MinIntValues_ReturnsCorrectSum()
     {
         int result = Add(int.MinValue, 0);
         Assert.Equal(int.MinValue, result);
     }
     ```

Các loại kiểm thử này giúp đảm bảo rằng mã của bạn hoạt động đúng trong mọi tình huống, từ các trường hợp thông thường đến các trường hợp bất thường và các giá trị biên.

Để xác định các giá trị cho **normal case**, **abnormal case**, và **boundary case** trong unit test, bạn có thể làm theo các bước sau:

1. **Normal Case**:
   - Xác định các đầu vào hợp lệ và phổ biến mà hàm hoặc phương thức của bạn sẽ xử lý.
   - Ví dụ: Nếu bạn đang kiểm tra hàm cộng hai số, các giá trị bình thường có thể là các số nguyên dương, số nguyên âm, và số 0.

     ```csharp
     [Fact]
     public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
     {
         int result = Add(2, 3);
         Assert.Equal(5, result);
     }
     ```

2. **Abnormal Case**:
   - Xác định các đầu vào không hợp lệ hoặc không mong đợi mà hàm hoặc phương thức của bạn có thể gặp phải.
   - Ví dụ: Nếu bạn đang kiểm tra hàm chia, bạn cần kiểm tra trường hợp chia cho số 0.

     ```csharp
     [Fact]
     public void Divide_ByZero_ThrowsException()
     {
         Assert.Throws<DivideByZeroException>(() => Divide(10, 0));
     }
     ```

3. **Boundary Case**:
   - Xác định các giá trị ở ranh giới của các đầu vào hợp lệ. Điều này bao gồm các giá trị cực đại và cực tiểu của kiểu dữ liệu, hoặc các giá trị ngay trước và sau các ngưỡng quan trọng.
   - Ví dụ: Nếu bạn đang kiểm tra hàm tính tổng, bạn cần kiểm tra với các giá trị cực đại và cực tiểu của kiểu `int`.

     ```csharp
     [Fact]
     public void Add_MaxIntValues_ReturnsCorrectSum()
     {
         int result = Add(int.MaxValue, 0);
         Assert.Equal(int.MaxValue, result);
     }

     [Fact]
     public void Add_MinIntValues_ReturnsCorrectSum()
     {
         int result = Add(int.MinValue, 0);
         Assert.Equal(int.MinValue, result);
     }
     ```

### Các bước cụ thể để xác định giá trị:

1. **Hiểu rõ yêu cầu và chức năng của hàm**:
   - Đọc kỹ yêu cầu và hiểu rõ chức năng của hàm hoặc phương thức bạn đang kiểm tra.

2. **Xác định các trường hợp sử dụng phổ biến**:
   - Liệt kê các trường hợp sử dụng phổ biến mà hàm sẽ xử lý. Đây sẽ là các giá trị cho **normal case**.

3. **Xác định các trường hợp bất thường**:
   - Xem xét các đầu vào không hợp lệ hoặc không mong đợi mà hàm có thể gặp phải. Đây sẽ là các giá trị cho **abnormal case**.

4. **Xác định các giá trị biên**:
   - Xem xét các giá trị ở ranh giới của các đầu vào hợp lệ. Đây sẽ là các giá trị cho **boundary case**.

Dưới đây là các giá trị điển hình cho các kiểu dữ liệu số, chuỗi, và ngày tháng trong C#:

### Kiểu Số (Numeric Types)
1. **int** (số nguyên 32-bit):
   - Giá trị nhỏ nhất: `int.MinValue` (−2,147,483,648)
   - Giá trị lớn nhất: `int.MaxValue` (2,147,483,647)
   - Giá trị điển hình: 0, 1, -1, 100, -100

2. **double** (số dấu phẩy động 64-bit):
   - Giá trị nhỏ nhất: `double.MinValue` (−1.7976931348623157E+308)
   - Giá trị lớn nhất: `double.MaxValue` (1.7976931348623157E+308)
   - Giá trị điển hình: 0.0, 1.0, -1.0, 3.14, -3.14

3. **decimal** (số dấu phẩy động 128-bit, độ chính xác cao):
   - Giá trị nhỏ nhất: `decimal.MinValue` (−79,228,162,514,264,337,593,543,950,335)
   - Giá trị lớn nhất: `decimal.MaxValue` (79,228,162,514,264,337,593,543,950,335)
   - Giá trị điển hình: 0.0m, 1.0m, -1.0m, 100.123m, -100.123m

### Kiểu Chuỗi (String Type)
1. **string**:
   - Giá trị rỗng: `string.Empty` hoặc `""`
   - Giá trị null: `null`
   - Giá trị điển hình: "Hello", "World", "123", "abc", "A long string with multiple words."

### Kiểu Ngày Tháng (DateTime Type)
1. **DateTime**:
   - Giá trị nhỏ nhất: `DateTime.MinValue` (01/01/0001 00:00:00)
   - Giá trị lớn nhất: `DateTime.MaxValue` (31/12/9999 23:59:59)
   - Giá trị điển hình: `DateTime.Now` (ngày giờ hiện tại), `DateTime.Today` (ngày hiện tại, thời gian là 00:00:00), `new DateTime(2025, 2, 3)` (ngày cụ thể)

Kỹ thuật kẻ đường giá trị (Boundary Value Analysis) là một phương pháp kiểm thử phần mềm giúp xác định các giá trị kiểm thử cho **normal case**, **abnormal case**, và **boundary case**. Dưới đây là cách bạn có thể áp dụng kỹ thuật này:

### 1. Xác định các giá trị biên (Boundary Values)
- **Boundary Values** là các giá trị nằm ở ranh giới của các đầu vào hợp lệ. Bạn cần xác định các giá trị này để kiểm tra xem hệ thống có xử lý đúng các giá trị ở ranh giới hay không.
- Ví dụ: Nếu bạn có một trường nhập số nguyên từ 1 đến 100, các giá trị biên sẽ là 1 và 100.

### 2. Xác định các giá trị bình thường (Normal Values)
- **Normal Values** là các giá trị nằm trong khoảng hợp lệ nhưng không phải là giá trị biên. Đây là các giá trị mà hệ thống sẽ thường xuyên gặp phải.
- Ví dụ: Với trường nhập số nguyên từ 1 đến 100, các giá trị bình thường có thể là 50, 75.

### 3. Xác định các giá trị bất thường (Abnormal Values)
- **Abnormal Values** là các giá trị nằm ngoài khoảng hợp lệ. Bạn cần kiểm tra xem hệ thống có xử lý đúng các giá trị không hợp lệ này hay không.
- Ví dụ: Với trường nhập số nguyên từ 1 đến 100, các giá trị bất thường có thể là 0, 101, -1, 200.

### Ví dụ cụ thể
Giả sử bạn có một hàm kiểm tra tuổi hợp lệ từ 18 đến 65:

```csharp
public bool IsValidAge(int age)
{
    return age >= 18 && age <= 65;
}
```

#### Normal Case
- Các giá trị bình thường: 20, 30, 50

```csharp
[Fact]
public void IsValidAge_NormalValues_ReturnsTrue()
{
    Assert.True(IsValidAge(20));
    Assert.True(IsValidAge(30));
    Assert.True(IsValidAge(50));
}
```

#### Boundary Case
- Các giá trị biên: 18, 65

```csharp
[Fact]
public void IsValidAge_BoundaryValues_ReturnsTrue()
{
    Assert.True(IsValidAge(18));
    Assert.True(IsValidAge(65));
}
```

#### Abnormal Case
- Các giá trị bất thường: 17, 66, -1, 100

```csharp
[Fact]
public void IsValidAge_AbnormalValues_ReturnsFalse()
{
    Assert.False(IsValidAge(17));
    Assert.False(IsValidAge(66));
    Assert.False(IsValidAge(-1));
    Assert.False(IsValidAge(100));
}
```

Đường giá trị
```
----AB----BD----NC----BD----AB----
----------18----------65----------
```

# Homework

Viết lại các function trong Sample library sao cho không còn bug.
Sử dụng kỹ thuật đường thẳng giá trị để chứng mình đã xử lý hết tất cả các trường hợp.