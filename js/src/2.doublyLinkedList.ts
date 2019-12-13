namespace DoublyLinkedList {
  class Node<T> {
    private _value: T;
    public get value(): T {
      return this._value;
    }
    public set value(v: T) {
      this._value = v;
    }

    private _next: Node<T>;
    public get next(): Node<T> {
      return this._next;
    }
    public set next(v: Node<T>) {
      this._next = v;
    }

    private _prev: Node<T>;
    public get previous(): Node<T> {
      return this._prev;
    }
    public set previous(v: Node<T>) {
      this._prev = v;
    }

    constructor(nodeValue: T) {
      this._value = nodeValue;
      this._next = null;
      this._prev = null;
    }
  }

  class DoublyLinkedList<T> {
    //#region " Properties "

    private _head: Node<T>;
    public get head(): Node<T> {
      return this._head;
    }
    public set head(node: Node<T>) {
      this._head = node;
    }

    private _tail: Node<T>;
    public get tail(): Node<T> {
      return this._tail;
    }
    public set tail(node: Node<T>) {
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
      this.head = null;
      this.tail = null;
      this.length = 0;
    }

    /**
     * Adds a node to the end of the linked list
     * @param value Value to be stored in the Doubly linked list node
     */
    push(value: T): boolean {
      let newNode = new Node(value);
      if (this.length === 0) {
        this.head = newNode;
        this.tail = newNode;
      } else {
        this.tail.next = newNode;
        newNode.previous = this.tail;
        this.tail = newNode;
      }
      this.length++;
      return true;
    }

    /**
     * Removes a node at the end of the linked list and will return the node value
     */
    pop(): Node<T> {
      if (this.length === 0) return undefined;
      let poppedNode = this.tail;
      if (this.length === 1) {
        this.head = null;
        this.tail = null;
      } else {
        this.tail = poppedNode.previous;
        this.tail.next = null;
        poppedNode.previous = null;
      }
      this.length--;
      return poppedNode;
    }

    /**
     * Removes a node form the beginning of the linked list and will return the node value
     */
    shift(): T {
      if (this.length === 0) return undefined;
      var oldHead = this.head;
      if (this.length === 1) {
        this.head = null;
        this.tail = null;
      } else {
        this.head = oldHead.next;
        this.head.previous = null;
        oldHead.next = null;
      }
      this.length--;
      return oldHead.value;
    }

    /**
     * Adds a node at the beginning of the linked list
     * @param value Value to be stored at the beginning of the linked list
     */
    unshift(value: T): boolean {
      var newNode = new Node(value);
      if (this.length === 0) {
        this.head = newNode;
        this.tail = newNode;
      } else {
        this.head.previous = newNode;
        newNode.next = this.head;
        this.head = newNode;
      }
      this.length++;
      return true;
    }

    /**
     * Returns the node at the specified index of the linked list.
     * If index = 0; first element in the list is returned.
     * If index = 3; fourth element in the list is returned.
     * @param index Index of the node to be retrieved
     */
    get(index: number): Node<T> {
      if (index < 0 || index >= this.length) return null;
      var count, current;
      if (index <= this.length / 2) {
        count = 0;
        current = this.head;
        while (count !== index) {
          current = current.next;
          count++;
        }
      } else {
        count = this.length - 1;
        current = this.tail;
        while (count !== index) {
          current = current.previous;
          count--;
        }
      }
      return current;
    }

    /**
     * Updates the value of the node at the specified index.
     * If index = 0; Value of the first element in the list is updated.
     * If index = 3; Value of the fourth element in the list is updated.
     * @param index Index of the node to be updated
     * @param value New value of the node
     */
    set(index: number, value: T): boolean {
      var foundNode = this.get(index);
      if (foundNode != null) {
        foundNode.value = value;
        return true;
      }
      return false;
    }

    /**
     * Inserts a new node at the specified index.
     * @param index Index at which the new node has to be inserted
     * @param value Value of the new node to be inserted
     */
    insert(index: number, value: T): boolean {
      if (index < 0 || index > this.length) return false;
      if (index === 0) return !!this.unshift(value);
      if (index === this.length) return !!this.push(value);

      var newNode = new Node(value);
      var prevNode = this.get(index - 1);
      var nextNode = prevNode.next;

      prevNode.next = newNode;
      newNode.previous = prevNode;

      newNode.next = nextNode;
      nextNode.previous = newNode;
      this.length++;
      return true;
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
        return this.pop().value;
      } else {
        const prevNode = this.get(index - 1);
        const removeNode = prevNode.next;
        const nextNode = removeNode.next;

        prevNode.next = nextNode;
        nextNode.previous = prevNode;

        removeNode.next = null;
        removeNode.previous = null;

        this._length--;
        return removeNode.value;
      }
    }
  }
}
