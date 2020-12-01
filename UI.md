# Unity UI: Common components

Table of contents

1. [`var`, `let` and `const`](#1-var-let-and-const)
2. [Arrow function](#2-arrow-function)
3. [Import and Export](#3-import-and-export)
4. [Classes, Properties and Methods](#4-classes-properties-and-methods)
5. [Spread operators and Rest parameters](#5-spread-operators-and-rest-parameters)
6. [Destructuring](#6-destructuring)
7. [Reference and Primitive types](#7-reference-and-primitive-types)
8. [Array functions](#8-array-functions)

---

## 1. `var`, `let` and `const`

### 1.1 Var

#### Scope: globally scoped or function/locally scoped

`var` là câu lệnh dùng để khai báo biến có phạm vi là **function scoped** hoặc **globally scoped**.  
Scope của biến là Global khi chúng ta khai báo biến bên ngoài function block. Tương tự, scope của biến là function scoped khi biến được khai báo bên trong block của function.

```javascript
var name = 'thaibm'; // globally scoped

function newFunction() {
  var age = '25'; // function scoped
}

console.log(name); // output: thaibm
console.log(age); // Uncaught ReferenceError: age is not defined
```

#### Var variables: re-declared and updated

Biến được khai báo bởi `var` có thể được tái khai báo và update.

```javascript
var name = 'thaibm';
var name = 'quytm'; // re-declared
```

và

```javascript
var name = 'thaibm';
name = 'quytm'; // update
```
