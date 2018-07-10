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

#### Projection providers

To simplify creation of projections you can use **Projection provider**. It can build you a projection by given original node.

To implement custom **Projection provider**, use a `IProjectionProvider` interface.

### Commands

You can use commands when you need to do something special with given Node. Command is just a `Action<Node>` delegate that runs
using Node.ExecuteCommand(Action<Node>) method with node as a parameters.

### Views & Projection boxes

With Views and boxes begins Unity part of DataTree. 

**ProjectionBox**: container for projection Node. Inherit it to create custom ProjectionBox for your type of Node.

**View**: script that binds some Node on specific Unity view (text, inputfield, etc.). Uses ProjectionBox as provider for Node to bind.
  Ready to use Views:
  - **TextView**: view for Text (read only)
  - **InputFieldView**: view for InputField (read/write)
  - **CollectionView**: base class to every view that react on children change of specific view and binds some GameObject's to it (read only)
  You can easly create custom views by creating subclass for View.

All-in-one picture:

<img align="center" src="https://i.imgur.com/yU0rqQD.jpg">

## Example

See `Example` folder.

## Documentation

**TODO**

## Some problems of implementation

- **Boxing and unboxing** when using value type for Node data
- **No "guard" and no safe way to interact with Main tree**
- **Commands may be potentially insecure**
