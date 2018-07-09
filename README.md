# DataTree
Proof-of-concept tree-based architecture pattern for Unity based on MVVM, Redux, Vuex. etc.

## Concept

### Data tree

All data presented as tree of **Nodes**. Each **Node** has a **Data** (value, actually) and may have child nodes:
<img align="center" src="https://i.imgur.com/6V0hjaO.png">

### Projection

When we need some sub-tree that represents part of a main tree, we use a **Projection**. Projection is a tree that 
is built from **original Node** and automatically binded on them.

#### Binding

Binding means that data between two Nodes is linked in some of ways:
- **Read**: projection recieves new data every time when original is updating
- **Write**: when projection updates it data, original recives it
- **Read/Write**: using both ways together

Projection can map not always on whole tree branch, but on any part of it:

<img align="center" src="https://i.imgur.com/cGb1N0w.jpg">

Projection can map on different Nodes across tree.
Also projection may use other projections as originals.

#### Projection schemes

**TODO**

### Commands

**TODO**

### Views & Boxes

**TODO**

## Documentation

**TODO**
