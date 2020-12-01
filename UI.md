# Unity UI: Common components

Table of contents

1. [`var`, `let` and `const`](#1-var-let-and-const)
2. [Button] (#2 Button text here ?)

---

## 1. `var`, `let` and `const`

### 1.1 Var

#### Scope: globally scoped or function/locally scoped

`var` là câu lệnh dùng để khai báo biến có phạm vi là **function scoped** hoặc **globally scoped**.  


```javascript
var name = 'thaibm'; // globally scoped

function newFunction() {
  var age = '25'; // function scoped
}

console.log(name); // output: thaibm
console.log(age); // Uncaught ReferenceError: age is not defined
```

## 2.Button
Button PagChomp

