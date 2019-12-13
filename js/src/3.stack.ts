namespace Stack {
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

  class Stack<T> {
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
     * Creates a new instance of Stack with 0 elements in it.
     */
    constructor() {
      this._first = null;
      this._last = null;
      this.size = 0;
    }

    /**
     * Adds a new element to the top of the stack.
     * @param value Returns the success of the operation
     */
    push(value: T): boolean {
      const newElement = new Element(value);
      if (this._size == 0) {
        this._first = newElement;
        this._last = newElement;
      } else {
        // Add the element at the beginning of the linked list
        const temp = this._first;
        this._first = newElement;
        this._first.next = temp;
      }
      this._size++;
      return true;
    }

    /**
     * Removes an element from the top of the stack and returns its value
     */
    pop(): T {
      if (this._size == 0) return null;
      let temp = this._first;
      this._first = temp.next;
      temp.next = null;
      this._size--;
      return temp.value;
    }
  }

  let s = new Stack<number>();
  s.push(1);
  s.push(2);
  s.push(3);
  console.log(s);
  console.log(s.pop());
  console.log(s.pop());
  console.log(s.pop());
  console.log(s.pop());
  console.log(s.pop());
  console.log(s.pop());
  console.log(s.pop());
}
