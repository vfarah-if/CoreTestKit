[TOC]

# Ornate Statue Requirements Specification

Hi and welcome to the Ornate Statue store. We only the finest goods, however our goods are 
constantly degrading in `Quality` as they approach their sell by date.

We have a system in place that updates our inventory for us. Your task is to add the new feature to our system so that
we can begin selling a new category of items. First an introduction to our system:

- All `items` have a `SellIn` value which denotes the number of days we have to sell the `items`
- All `items` have a `Quality` value which denotes how valuable the item is
- At the end of each day our system lowers both values for every item

Pretty simple, right? Well this is where it gets interesting:

- Once the sell by date has passed, `Quality` degrades twice as fast
- The `Quality` of an item is never negative
- __"Aged Brie"__ actually increases in `Quality` the older it gets
- The `Quality` of an item is never more than `50`
- __"Diamond ring"__, being a valuable item, never has to be sold or decreases in `Quality`
- __"Backstage passes"__, like aged brie, increases in `Quality` as its `SellIn` value approaches;
	- `Quality` increases by `2` when there are `10` days or less and by `3` when there are `5` days or less but
	- `Quality` drops to `0` after the concert

Just for clarification, an item can never have its `Quality` increase above `50`, however __"Diamond ring"__ is a
highly sought after item and as such its `Quality` is `80` and it never alters.

We have recently signed a supplier of fresh items. This requires an update to our system:

- __"Fresh apples"__ items degrade in `Quality` twice as fast as normal items

Feel free to make any changes to the `UpdateQuality` method and add any new code as long as everything
still works correctly. However, do not alter the `Item` class or `Store` constructor.

# Steps and notes

Certainly, Vincent.

The **Gilded Rose Kata** is a well-known legacy refactoring exercise popularised by Emily Bache. Its aim is to teach developers how to **refactor safely**, write **characterisation tests**, and apply **SOLID principles**, especially **Open/Closed**. The original implementation is deliberately messy and requires thoughtful refactoring.

Here’s how the kata works, then how you can approach it in **.NET**.

### 🧠 Problem Summary

You’re maintaining a shop’s inventory system. Every item has:

- **Name**
- **SellIn**: the number of days we have to sell the item
- **Quality**: how valuable the item is

At the end of each day, your system updates both `SellIn` and `Quality` for every item.

#### General Rules

1. `Quality` degrades by 1 each day.
2. Once the `SellIn` date passes, `Quality` degrades twice as fast.
3. `Quality` is never negative.
4. `Quality` is never more than 50.
5. Some items behave differently:
   - **Aged Brie**: increases in quality the older it gets.
   - **Backstage passes**:
     - +1 quality when >10 days left
     - +2 quality when ≤10 days
     - +3 quality when ≤5 days
     - Quality drops to 0 after the concert
   - **Sulfuras**: legendary item; never changes in `SellIn` or `Quality` (which is always 80).
   - (Optional extension) **Conjured items** degrade in quality twice as fast as normal.

### ✅ Your Task

The original implementation has a large `UpdateQuality()` method, often using conditionals or `switch` statements on item names.

Your job is to **refactor it** so that it’s:

- Easier to test
- Easier to extend (i.e. for new items)
- Follows good OO and clean code principles

### 🧰 .NET Implementation Walkthrough

### 1. Starting Point – Legacy Code

Look through it but there are several rules in place that need to be adhered to

### 2. First Step – Characterisation Tests

Before you refactor, **write tests** to capture the current behaviour. This gives you a safety net.

Write tests only for each special case, or uncomment what needs to be exposed when you get to it.

### 3. Refactor – Apply Open/Closed Principle

Instead of a giant `if` or `switch`, but mostly do very small safe changes to understand the what needs to be done **model each item type as a strategy** or **inheritance-based polymorphism**.

#### 🔁 How to Practise

- Start from the messy implementation
- Write [characterisation tests](https://en.wikipedia.org/wiki/Characterization_test) - **partially done**
- Refactor gradually
- Follow TDD
- Try implementing `Fresh apples` items last

#### 🧪 Recommended Tools

- **xUnit** for tests
- Try strategy-based

#### 🧭 Teaching/Workshop Format

When running it as a kata in a team:

- Pair programme in baby steps
- Focus on refactoring strategies: extract method, introduce polymorphism, replace conditionals
- Debrief at the end

## 🔧 Refactoring at the Seams – Theory & Patterns

**"Refactoring at the seams"** is a concept that arises when working with **legacy code**—especially code that’s **hard to change safely**. The term "seam" was popularised by Michael Feathers in *Working Effectively with Legacy Code*. A **seam** is a **place where you can change behaviour in your program without editing that place directly**.

Understanding seams helps you:

- Introduce tests to untested legacy code
- Replace parts of the system (e.g. collaborators, dependencies)
- Decompose monoliths
- Move towards SOLID design

### 💡 What Is a Seam?

> A **seam** is a joint in software where you can alter behaviour without modifying the surrounding code.

There are three primary kinds of seams:

#### 1. Preprocessor Seams (mostly in C/C++)

You use `#ifdef` to change code inclusion. Not common in .NET.

#### 2. Link Seams

You swap out linked components at compile or load time (e.g. using interfaces or dependency injection in .NET).

#### 3. Object Seams

You use polymorphism or dependency injection to change behaviour—*most common in OO languages like C#*.

### 🤹 Common Refactoring Patterns to Create/Exploit Seams

These patterns help you introduce flexibility and testability.

#### 1. **Extract Method / Function**

✅ *Purpose*: Isolate a piece of logic to make it independently testable or swappable.

🔧 *Use when*:

- You need to test something deep in a large method
- You want to reuse the logic

🔁 *Example*:

```csharp
void UpdateQuality() {
    foreach (var item in items) {
        UpdateItemQuality(item); // seam
    }
}
```

#### 2. **Introduce Strategy / Replace Conditional with Polymorphism**

✅ *Purpose*: Replace `if`/`switch` with a pluggable implementation.

🔧 *Use when*:

- Behaviour varies by type, name, or category
- New types need to be added without editing existing code

🔁 *Example* (as in the Gilded Rose):

```csharp
abstract class UpdatableItem {
    public abstract void Update();
}
```

#### 3. **Extract Interface / Introduce Interface**

✅ *Purpose*: Enable mocking, stubbing, or alternative implementations for collaborators.

🔧 *Use when*:

- A class is hard-wired into consumers
- You want to inject fakes/mocks in tests

🔁 *Example*:

```csharp
public interface IItemUpdater {
    void Update(Item item);
}
```

#### 4. **Dependency Injection**

✅ *Purpose*: Externalise creation of dependencies, enabling test seams and flexibility.

🔧 *Use when*:

- A class internally constructs objects you want to control

🔁 *Example*:

Before:

```csharp
var service = new InventoryService();
```

After:

```csharp
public class OrderProcessor {
    public OrderProcessor(IInventoryService inventory) { ... }
}
```

#### 5. **Encapsulate Global References**

✅ *Purpose*: Remove hard dependencies on static classes, configuration, or environment

🔧 *Use when*:

- You want to stub or control environment-dependent behaviour in tests

🔁 *Example*:

```csharp
public interface IClock {
    DateTime Now { get; }
}
```

#### 6. **Introduce Gateway / Facade**

✅ *Purpose*: Wrap complex APIs or services to isolate change and provide test seams.

🔧 *Use when*:

- External systems or SDKs are tightly coupled

🔁 *Example*:

```csharp
public interface IPricingGateway {
    decimal GetPrice(string sku);
}
```

#### 7. **Wrap Primitive or Replace Magic Constant**

✅ *Purpose*: Give meaningful names and encapsulate logic inside value objects.

🔧 *Use when*:

- Behaviour is tied to a primitive or string identifier (e.g. item name)

🔁 *Example*:

Before:

```csharp
if (item.Name == \"Aged Brie\") ...
```

After:

```csharp
var itemType = ItemType.Parse(item.Name);
```

### 🧪 Using Seams for Testing

A common goal of introducing seams is to **enable testing** where none existed before.

#### Legacy code anti-pattern:

```csharp
public void UpdateQuality()
{
    // big loop with lots of ifs, no test entry point
}
```

#### Refactor into testable pieces:

- Extract `UpdateItem`
- Replace item-type conditionals with polymorphic classes
- Inject collaborators

# 🧠 Summary

| Pattern                                    | Purpose                              |
| ------------------------------------------ | ------------------------------------ |
| Extract Method                             | Isolate logic and create a test seam |
| Replace Conditional with Polymorphism      | Support Open/Closed principle        |
| Introduce Interface / Dependency Injection | Create test seams and flexibility    |
| Encapsulate Global Reference               | Stub/replace environment in tests    |
| Introduce Gateway                          | Isolate external dependencies        |
| Wrap Primitive                             |                                      |

