# DataStructure

### 装箱和拆箱

装箱：值类型转换为引用类型
拆箱：引用类型转换为值类型
引用类型：任何称为"类"的类型都是引用类型，使用 class 修饰；如：string，object
值类型：所有值类型都称为结构或枚举，使用 struct 或 enum 修饰；如: int，float，double，char

### 泛型和非泛型

泛型数组 List 有两个优势：
第一个是对存储值类型数据，性能更优
第二个是使代码更清晰和保证类型安全
why：为什么还保留着 ArrayList?
ans：因为早期 C#并没有泛型，所以使用 ArrayList，它存储的 object 引用类型，留着是为了兼容老项目
ArrayList 存引用类型的数据没有发生装箱的操作，但转 object 有消耗，取引用类型的数据取出来是 object，object 转其他引用类型有消耗
所以在使用上尽量使用 List
