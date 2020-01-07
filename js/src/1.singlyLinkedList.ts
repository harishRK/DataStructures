class ListNode<T> {
  private _value: T;
  public get value(): T {
    return this._value;
  }
  public set value(v: T) {
    this._value = v;
  }

  private _next: ListNode<T>;
  public get next(): ListNode<T> {
    return this._next;
  }
  public set next(v: ListNode<T>) {
    this._next = v;
  }

  constructor(nodeValue: T) {
    this._value = nodeValue;
    this._next = null;
  }
}

class SinglyLinkedList<T> {
  //#region " Properties "

  private _head: ListNode<T>;
  public get head(): ListNode<T> {
    return this._head;
  }
  public set head(node: ListNode<T>) {
    this._head = node;
  }

  private _tail: ListNode<T>;
  public get tail(): ListNode<T> {
    return this._tail;
  }
  public set tail(node: ListNode<T>) {
    this._tail = node;
  }

  private _length: number;
  public get length(): number {
    return this._length;
  }
  public set length(v: number) {
    this._length = v;
  }

  //#endregion

  constructor() {
    this._length = 0;
    this._head = null;
    this._tail = null;
  }

  /**
   * Adds a node to the end of the linked list
   * @param value Value to be stored in the linked list node
   */
  push(value: T) {
    let newNode = new ListNode(value);

    // If head is null (empty linked list), then assign both head and tail to the new node
    if (this._head === null) {
      this._head = newNode;
      this._tail = this._head;
    } else {
      this._tail.next = newNode;
      this._tail = newNode;
    }
    // Increment the length of the linked list
    this._length++;
  }

  /**
   * Removes a node at the end of the linked list and will return the node value
   */
  pop(): T {
    if (this._length === 0) {
      return undefined;
    } else if (this._head === this._tail) {
      const returnNode: ListNode<T> = this._head;
      this._head = null;
      this._tail = null;
      this._length = 0;
      return returnNode.value;
    } else {
      let returnNode: ListNode<T>;
      let newTailNode: ListNode<T>;
      let currentNode = this._head;
      // Find the node before the tail node
      while (currentNode.next) {
        newTailNode = currentNode;
        currentNode = currentNode.next;
      }
      // Set the tail to the new tail node
      returnNode = this._tail;
      newTailNode.next = null;
      this._tail = newTailNode;
      // Decrement the length of the linked list
      this._length--;

      return returnNode.value;
    }
  }

  /**
   * Removes a node form the beginning of the linked list and will return the node value
   */
  shift(): T {
    if (this._length === 0) {
      return undefined;
    } else if (this._head === this._tail) {
      const returnNode = this._head;
      this._head = null;
      this._tail = null;
      this._length = 0;
      return returnNode.value;
    } else {
      const returnNode = this._head;
      this._head = returnNode.next;
      returnNode.next = null;
      this._length--;

      return returnNode.value;
    }
  }

  /**
   * Adds a node at the beginning of the linked list
   * @param value Value to be stored at the beginning of the linked list
   */
  unShift(value: T) {
    const node = new ListNode<T>(value);
    if (this._length === 0) {
      this._head = node;
      this.tail = node;
    } else {
      node.next = this._head;
      this._head = node;
    }
    this._length++;
  }

  /**
   * Returns the node at the specified index of the linked list.
   * If index = 0; first element in the list is returned.
   * If index = 3; fourth element in the list is returned.
   * @param index Index of the node to be retrieved
   */
  get(index: number): ListNode<T> {
    if (this._length === 0 || index > this._length - 1 || index < 0) {
      return undefined;
    } else {
      let returnNode: ListNode<T> = this._head;
      for (let i = 1; i <= index; i++) {
        returnNode = returnNode.next;
      }
      return returnNode;
    }
  }

  /**
   * Updates the value of the node at the specified index.
   * If index = 0; Value of the first element in the list is updated.
   * If index = 3; Value of the fourth element in the list is updated.
   * @param index Index of the node to be updated
   * @param value New value of the node
   */
  set(index: number, value: T): boolean {
    let node = this.get(index);
    if (node) {
      node.value = value;
      return true;
    } else {
      return false;
    }
  }

  /**
   * Inserts a new node at the specified index.
   * @param index Index at which the new node has to be inserted
   * @param value Value of the new node to be inserted
   */
  insert(index: number, value: T): boolean {
    if (index < 0 || index > this._length) {
      return false;
    } else if (index === 0) {
      this.unShift(value);
      return true;
    } else if (index === this._length) {
      this.push(value);
      return true;
    } else {
      const prevNode = this.get(index - 1);
      const nextNode = prevNode.next;

      const newNode = new ListNode<T>(value);
      prevNode.next = newNode;
      newNode.next = nextNode;
      this._length++;
      return true;
    }
  }

  /**
   * Removes a node at the specified index and returns its value.
   * @param index Index at which the node has to be removed.
   */
  remove(index: number): T {
    if (index < 0 || index > this._length - 1) {
      return null;
    } else if (index === 0) {
      return this.shift();
    } else if (index === this._length - 1) {
      return this.pop();
    } else {
      const prevNode = this.get(index - 1);
      const removeNode = prevNode.next;
      prevNode.next = removeNode.next;
      removeNode.next = null;
      this._length--;
      return removeNode.value;
    }
  }

  reverse() {
    //Swap head and tail nodes
    let node = this._head;
    this._head = this._tail;
    this._tail = node;

    let prevNode: ListNode<T> = null;
    let nextNode: ListNode<T>;
    for (let i = 0; i < this._length; i++) {
      nextNode = node.next;
      node.next = prevNode;
      prevNode = node;
      node = nextNode;
    }
  }

  print() {
    let arr: T[] = [];
    let current = this._head;
    while (current) {
      arr.push(current.value);
      current = current.next;
    }
    console.log(arr);
  }
}

let ls = new SinglyLinkedList<number>();
console.log(ls.length);
ls.push(0);
ls.push(1);
ls.push(2);

ls.print();

// console.log(ls.pop());
// console.log(ls.pop());
// console.log(ls.pop());
// console.log(ls.pop());

// console.log(ls.shift());
// console.log(ls.shift());
// console.log(ls.shift());
// console.log(ls.shift());

// console.log(ls.unShift(-1));
// console.log(ls.unShift(-2));
// console.log(ls.unShift(-3));
// console.log(ls.unShift(-4));

// console.log(ls.set(3, 100));
// console.log(ls.get(1));
// console.log(ls.insert(1, -1));
// console.log(ls.get(1));
ls.reverse();
ls.print();
