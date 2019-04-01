## Decorator Design Pattern

### Çalışma Mantığı

Bu tasarım deseni, soyutlayarak gevşek bağlılığı sağladığımız sistemimizde mevcut yapımız için yeni metotlar ekleneceği zaman kullanılır. Sisteme mevcut kodu bozmadan dinamik metotlar ekleyebileceğimiz bir yapıdadır. Sistemi bu hale getirebilmek için yapının ara yüzünden türeyen bir adet decorator sınıf yazılır. Yazılan bu sınıfın içerisinde kendi türediği sınıfa bir bağımlılık yani referans barındırır.

Anlaşılması ilk başta biraz karmaşık gelen bu tasarım kalıbı yeni eklenen yetenekler için kullanılır. Hemen şu şekilde düşünebilirsiniz, bu kadar takla atmak yerine kendi sistem ara yüzümüzden türeyen yeni bir sınıf oluşturur, sistemimi bu şekilde genişletirim. Evet, bu doğru, zaten bundan sonraki tercihlerimiz bizim yoğurt yiyişimizi belirleyecek.


### Ne zaman kullanılır?

Bu tasarım deseni sistemin genişlemesi için biçilmiş kaftandır. Mevcut bir işlemi, yani metotları yazdıktan sonra o metotlardan beklentimiz giderek artar. Sonuç olarak o metodun satır sayısı giderek uzar ve ilk yazıldığı an verilen metot ismi ile alakası olmayan veya çok az alakası olan bir iş yapmaya başlar.

Bunu yapmayıp sistemin ara yüzüne yeni metotlar da eklenebilir aslında. Ancak o zamanda ara yüzü şişirmiş oluruz. Bu da ara yüz ayrım prensibine uymaz. Eğer yeni bir özellik eklemek için ara yüzümüzü hiç alakası olmayan bir şekilde genişletmemiz gerekiyorsa bu bizim için bir sinyaldir.

Refactoring dediğimiz sistemi yeniden ele alırken de kullanılır. Aynı ara yüzden türeyen nesnelerinizden bazıları için yeni özellik eklenecek ve bazıları için de eklenmeyecek. Bu tarz bir durumda ara yüzümüzü genişletsek dummy code yazmak zorunda kalacağız. Böyle bir senaryoda ya decorator pattern’i kullanırdık ya da ara yüzlerimizi ayırıp ortak bir arayüzden türetmeye çalışırdık ki buradan sonrası ihtiyaca, öngörüye, yoğurt yiyişe göre değişir.

Alt sınıf oluşturmanın artık pratik olmadığını düşünüyorsanız decorator yazılması gerekir.

### Örnek

Veri tabanındaki işlemler için bir sistemimiz olsun. Bu sistemi gerçekleştirirken Repository pattern’i kullanarak yazdığımızı düşünelim. Veri tabanındaki tüm işlemleri bu sayede yapılabilir hale geldiğimizi varsayalım. Daha sonra beklenen acı son oldu ve değişiklik istekleri bir çığ gibi gelmeye başladı.

İş birimimizden gelen isteklerin şu şekilde olduğunu düşünelim. Select yaparken önce güvenlik kontrolü yapılsın ondan sonra veriler gösterilsin. Herhangi bir kayıt eklendiğinde, silindiğinde, güncellendiğinde bununla ilgili işlem yapan kişi ve tarihi loglansın. Herhangi bir kayıt silindiğinde veya güncellendiğinde CRM veri tabanına web servisler aracılığıyla bağlanıp aynı değişiklik orada da yapılsın. Herhangi bir kayıt güncellendiğinde bizim raporlama işleri için oluşturduğumuz DataWareHouse’umuzdan da güncellensin.

Halbuki bizim sadece CRUD işlemlerimiz için bir ara yüzümüz var ve bunu c#ta genericler sayesinde tek sınıfta halletmiştik. Çok da beğendik tasarımımızı halbuki. Nereden çıktı bu istekler?

Normalde bizim kodumuzda istekler gelmeden önce sadece IRepository ve EfRepository vardı. Bu sayede tüm veri tabanı işlemlerini yapıyorduk. Ekstra istekler gelince hemen sistemimizi decorator pattern’e çevirdik. Bunun için IRepository'den türeyen ve yapıcı metodunda yine başka bir IRepository türünden referans isteyen bir sınıf yaptık ve iş birimimizden gelen dört farklı ihtimal için de sınıflar oluşturduk. Bu sayede bambaşka bir şeyin daha yapılması isteği gelirse hiç sıkıntı yaşamadan yeni bir sınıf ekleyebileceğiz.
