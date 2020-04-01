namespace Queue {
  class Element<T> {
    private _value: T;
    public get value(): T {
      return this._value;
    }
    public set value(v: T) {
      this._value = v;
    }

    private _next: Element<T>;
    public get next(): Element<T> {
      return this._next;
    }
    public set next(v: Element<T>) {
      this._next = v;
    }

    constructor(val: T) {
      this._value = val;
      this._next = null;
    }
  }

  class Queue<T> {
    private _first: Element<T>;
    public get first(): Element<T> {
      return this._first;
    }
    public set first(elem: Element<T>) {
      this._first = elem;
    }

    private _last: Element<T>;
    public get last(): Element<T> {
      return this._last;
    }
    public set last(elem: Element<T>) {
      this._last = elem;
    }

    private _size: number;
    public get size(): number {
      return this._size;
    }
    public set size(v: number) {
      this._size = v;
    }

    /**
     * Creates a new instance of Queue with 0 elements in it.
     */
    constructor() {
      this._first = null;
      this._last = null;
      this.size = 0;
    }

    /**
     * Adds a new element to the end of the queue.
     * @param value Returns the success of the operation
     */
    Enqueue(value: T): boolean {
      const newElement = new Element(value);
      if (this._size == 0) {
        this._first = newElement;
        this._last = newElement;
      } else {
        // Add the element at the end of the linked list
        this._last.next = newElement;
        this._last = newElement;
      }
      this._size++;
      return true;
    }

    /**
     * Removes an element from the beginning of the queue and returns its value
     */
    Dequeue(): T {
      if (this._size == 0) return null;
      let prevFirst = this._first;
      this._first = prevFirst.next;
      prevFirst.next = null;
      this._size--;
      return prevFirst.value;
    }
  }

  let s = new Queue<number>();
  s.Enqueue(1);
  s.Enqueue(2);
  s.Enqueue(3);
  console.log(s);
  console.log(s.Dequeue());
  console.log(s.Dequeue());
  console.log(s.Dequeue());
  console.log(s.Dequeue());
  console.log(s.Dequeue());
  console.log(s.Dequeue());
  console.log(s.Dequeue());
}
