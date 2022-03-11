function Node(data) {
  this.data = data;
  this.next = null;
  this.prev = null;
}

function List() {
  this._length = 0;
  this.start = null;
  this.end = null;
}

List.prototype.add = function (value) {
  var node = new Node(value);

  if (this._length) {
    this.end.next = node; // Добавление нового узла с конца
    node.prev = this.end; // Конец списка добавляем как предшествующий Node
    this.end = node; // Теперь конец списка это Node
  } else {
    this.head = node; // Если пустой список
    this.tail = node;
  }
  this._length++;
  return node;
};

List.prototype.remove = function (position) {};
