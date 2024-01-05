# EventManager
 
EventManager kullanarak sınıflar arasında bilgi paylaşımı gerçekleştiriyorum. "Example" klasöründe, bu kullanımı örneklemek amacıyla bir senaryo oluşturdum.

UIController sınıfında tanımlanan Subscribe fonksiyonu, EventManager üzerindeki bir eventi dinlemekle görevlidir. Bu event, CharacterManager sınıfındaki TakeDamage fonksiyonu çağrıldığında tetiklenir. Bu durumda, dinleme işlemini gerçekleştiren sınıf, TakeDamage fonksiyonunun çağrılmasına tepki gösterir ve gerekli işlemleri gerçekleştirir.
