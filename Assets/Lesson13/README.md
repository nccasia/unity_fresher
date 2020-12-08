# Unity UI: Common components

Table of contents

1. [Button](#1-Button)
2. [Label](#2-Label)

---

## 1. Button

### 1.1 Var

#### Scope: globally scoped or function/locally scoped

`Button` là câu lệnh dùng để khai báo biến có phạm vi là **function scoped** hoặc **globally scoped**.  


```javascript
var name = 'thaibm'; // globally scoped

function newFunction() {
  var age = '25'; // function scoped
}

console.log(name); // output: thaibm
console.log(age); // Uncaught ReferenceError: age is not defined
```

## 2. Label
Label is 

