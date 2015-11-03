<!-- section start -->
<!-- attr: { class:'slide-title', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Sorting andSearching Algorithms
<div class="signature">
    <p class="signature-course">Data Structures and Algorithms</p>
    <p class="signature-initiative">Telerik Software Academy</p>
    <a href = "http://academy.telerik.com " class="signature-link">http://academy.telerik.com </a>
</div>

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Table of Contents
* Sorting
  * Sorting and classification
  * Review of the most popularsorting algorithms
* Searching
  * Linear search
  * Binary search
  * Interpolation search
* Shuffling

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Sorting

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# What is a Sorting Algorithm?
* Sorting algorithm
  * An algorithm that puts elements of a list in a certain order (most common lexicographically)
* More formally:
  * The output is in some (non-decreasing) order
  * The output is a permutation of the input
* Efficient sorting is important for
  * Producing human-readable output
  * Canonicalizing data
  * Optimizing the use of other algorithms
* Sorting presents many important techniques

<!-- attr: { showInPresentation:true, style:'' } -->
* Sorting algorithms are often classified by
  * Computational complexity
    * worst, average and best behavior
  * Memory usage
  * Recursive or non-recursive
  * Stability
  * Whether or not they are a comparison sort
  * General method
    * insertion, exchange (bubble sort and quicksort), selection (heapsort), merging, serial or parallel…
# Classification

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Stability of Sorting
* Stable sorting algorithms
  * Maintain the relative orderof records with equal values
* If two items compare asequal, then their relativeorder will be preserved
  * When sorting only part ofthe data is examinedwhen determining thesort order

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Selection sort
* Very simple and very inefficient algorithm
  * Best, worst and average case: `n2`
  * Memory: `1` (constant, only for the min element)
  * Stable: No
  * Method: Selection
  * http://en.wikipedia.org/wiki/Selection_sort

```cs
for (j = 0; j < n-1; j++) {
    /x find the min element in the unsorted a[j .. n-1] x/
    iMin = j;
    for ( i = j+1; i < n; i++) {
        if (a[i] < a[iMin]) iMin = i;
    }
    if (iMin != j) swap(a[j], a[iMin]);
}
```

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Bubble sort
* Repeatedly stepping through the list, comparing each pair of adjacent items and swap them if they are in the wrong order
  * Best case: `n`, worst and average case: `n2`
  * Memory: `1`, Stable: Yes, Method: Exchanging
  * http://en.wikipedia.org/wiki/Bubble_sort

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Insertion sort
* Builds the final sorted array one item at a time
  * Best case: `n`, worst and average case: `n2`
  * Memory: `1`, Stable: Yes, Method: Insertion
  * http://en.wikipedia.org/wiki/Insertion_sort

```cs
for i ← 1 to i ← length(A)-1
{
  valueToInsert ← A[i]
  holePos ← i
  while holePos > 0 and valueToInsert < A[holePos - 1]
  { 
    A[holePos] ← A[holePos - 1] // shift the larger value up
    holePos ← holePos - 1       // move the hole position down
  }
  A[holePos] ← valueToInsert
}
```

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Quicksort
* First divides a large list into two smaller sub-lists then recursively sort the sub-lists
  * Best and average case: `nxlog(n)`, worst: `n2`
  * Memory: `log(n)` stack space
  * Stable: Depends
  * Method: Partitioning
  * http://en.wikipedia.org/wiki/Quicksort
<div class="fragment balloon">Stable implementation</div>

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Merge Sort
* Conceptually, a merge sort works as follows
  * Divide the unsorted list into `n` sublists, each containing `1` element (list of 1 element is sorted)
  * Repeatedly merge sublists to produce new sublists until there is only 1 sublist remaining
* Best, average and worst case: `nxlog(n)`
* Memory: Depends; worst case is `n`
* Stable: Yes; Method: Merging
* Highly parallelizable (up to `O(log(n)`) using the Three Hungarian's Algorithm
* http://en.wikipedia.org/wiki/Merge_sort

<!-- attr: { showInPresentation:true, style:'' } -->
# Merge Sort Pseudocode

```cs
function merge_sort(list m)
*     // if list size is 0 (empty) or 1, consider it sorted
*     // (using less than or equal prevents infinite recursion for a zero length m)
    if length(m) <= 1
        return m
*     // else list size is > 1, so split the list into two sublists
    var list left, right
    var integer middle = length(m) / 2
    for each x in m before middle
         add x to left
    for each x in m after or equal middle
         add x to right
*     // recursively call merge_sort() to further split each sublist
*     // until sublist size is 1
    left = merge_sort(left)
    right = merge_sort(right)
*     // merge the sublists returned from prior calls to merge_sort()
*     // and return the resulting merged sublist
    return merge(left, right)
```

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Merge Sort Pseudocode (2)

```cs
function merge(left, right)
    var list result
    while length(left) > 0 or length(right) > 0
        if length(left) > 0 and length(right) > 0
            if first(left) <= first(right)
                append first(left) to result
                left = rest(left)
            else
                append first(right) to result
                right = rest(right)
        else if length(left) > 0
            append first(left) to result
            left = rest(left)
        else if length(right) > 0
            append first(right) to result
            right = rest(right)
    end while
    return result
```

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Heap
* Specialized tree-based data structure that satisfies the heap property:
  * Parent nodes are always greater (less) than or equal to the children
    * No implied orderingbetween siblings or cousins
* en.wikipedia.org/wiki/Heap_(data_structure)

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Heapsort
* Can be divided into two parts
  * In the first step, a heap is built out of the data
  * A sorted array is created by repeatedly removing the largest element from the heap
* Best, average and worst case: `nxlog(n)`
* Memory: Constant - `O(1)`
* Stable: No
* Method: Selection
* http://en.wikipedia.org/wiki/Heapsort

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Counting sort
* Algorithm for sorting a collection of objects according to keys that are small integers
* Not a comparison sort
* Average case: `n + r`
* Worst case: `n + r`
  * `r` is the range of numbers to be sorted
* Stable: Yes
* Memory: `n + r`
* http://en.wikipedia.org/wiki/Counting_sort

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Bucket sort
* Partitioning an array into a number of buckets
  * Each bucket is then sorted individually
* Not a comparison sort
* Average case: `n + k`
  * `k` = the number of buckets
* Worst case: `n2 x k`
* Stable: Yes
* Memory: `n x k`
* http://en.wikipedia.org/wiki/Bucket_sort

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Comparison of Sorting Algorithms
* There are hundreds of sorting algorithms

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Searching

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Search Algorithm 
* An algorithm for finding an item with specified properties among a collection of items
* Different types of searching algorithms
  * For virtual search spaces
    * satisfy specific mathematical equations
    * try to exploit partial knowledge about structure
  * For sub-structures of a given structure
    * graph, a string, a finite group
  * Search for the max (min) of a function
  * etc.

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Linear Search
* Method for finding a particular value in a list
  * Checking every one of the elements
  * One at a time in sequence
  * Until the desired one is found
* Worst and average performance: `O(n)`

```cs
 for each item in the list:
     if that item has the desired value,
         stop the search and return the item's location.
 return nothing.
```

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Binary Search
* Finds the position of a specified value within a `sorted` data structure
* In each step, compare the input with the middle
  * The algorithm repeats its action to the left or right sub-structure
* Average performance: `O(log(n))`

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Recursive Binary Search

```cs
int binary_search(int A[], int key, int imin, int imax)
{
  if (imax < imin)
*      // set is empty, so return value showing not found
     return KEY_NOT_FOUND;
  else
  {
*      // calculate midpoint to cut set in half
     int imid = midpoint(imin, imax);
     if (A[imid] > key)
*         // key is in lower subset
        return binary_search(A, key, imin, imid-1);
     else if (A[imid] < key)
*         // key is in upper subset
        return binary_search(A, key, imid+1, imax);
     else
*         // key has been found
        return imid;
  }
}
```

<!-- attr: { showInPresentation:true, style:'' } -->
# Iterative Binary Search

```cs
int binary_search(int A[], int key, int imin, int imax)
{
*    // continue searching while [imin,imax] is not empty
   while (imax >= imin)
   {
*       /x calculate the midpoint for roughly equal partition x/
      int imid = midpoint(imin, imax);
*       // determine which subarray to search
      if (A[imid] < key)
*          // change min index to search upper subarray
         imin = imid + 1;
      else if (A[imid] > key)
*          // change max index to search lower subarray
         imax = imid - 1;
      else
*          // key found at index imid
         return imid;
  }
  return KEY_NOT_FOUND;
}
```

<!-- attr: { showInPresentation:true, style:'' } -->
# Interpolation Search
* An algorithm for searching for a given key value in an indexed array that has been ordered by the values of the key
  * Parallels how humans search through a telephone book
  * Calculates where in the remaining search space the sought item might be
    * Binary search always chooses the middle element
* Average case: `log(log(n))`, Worst case: `O(n)`
* http://youtube.com/watch?v=l1ed_bTv7Hw

<!-- attr: { showInPresentation:true, style:'' } -->
# Interpolation SearchSample Implementation

```cs
public int interpolationSearch(int[] sortedArray, int toFind){
*   // Returns index of toFind in sortedArray, or -1 if not found
  int low = 0;
  int high = sortedArray.length - 1;
  int mid;
  while(sortedArray[low] <= toFind && sortedArray[high] >= toFind) {
    mid = low + ((toFind - sortedArray[low]) x (high - low)) /
                (sortedArray[high] - sortedArray[low]);
*                 // out of range is possible here
    if (sortedArray[mid] < toFind)
      low = mid + 1;
    else if (sortedArray[mid] > toFind)
      high = mid - 1;
    else
      return mid;
  }
  if (sortedArray[low] == toFind) return low;
*   else return -1; // Not found
}
```

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Shuffling

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Shuffling
* A procedure used to randomize the order of items in a collection
  * Generating random permutation
* http://en.wikipedia.org/wiki/Shuffling

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Fisher–Yates shuffle algorithm

```cs
public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
{
    var array = source.ToArray();
    var n = array.Length;
    for (var i = 0; i < n; i++)
    {
*         // Exchange a[i] with random element in a[i..n-1]
        int r = i + RandomProvider.Instance.Next(0, n - i);
        var temp = array[i];
        array[i] = array[r];
        array[r] = temp;
    }
    return array;
}
public static class RandomProvider
{
    private static Random Instance = new Random();
}
```

<!-- attr: { showInPresentation:true, style:'' } -->
# Sorting and Searching Algorithms
* http://academy.telerik.com

<!-- attr: { showInPresentation:true, style:'' } -->
# Homework
* Open `Sorting-and-Searching-Algorithms-Homework.zip` and:
  * Implement `SelectionSorter.Sort()` method using selection sort algorithm
  * Implement `Quicksorter.Sort()` method using quicksort algorithm
  * Implement `MergeSorter.Sort()` method using merge sort algorithm
  * Implement `SortableCollection.LinearSearch()` method using linear search
    * Don’t use built-in search methods. Write your own.

<!-- attr: { showInPresentation:true, style:'' } -->
# Homework (2)
  * Implement `SortableCollection.BinarySearch()` method using binary search algorithm
  * Implement `SortableCollection.Shuffle()` method using shuffle algorithm of your choice
    * Document what is the complexity of the algorithm
  * x Unit test sorting algorithms
    * `SelectionSorter.Sort()`
    * `Quicksorter.Sort()`
    * `MergeSorter.Sort()`
  * x Unit test searching algorithms
    * `SortableCollection.LinearSearch()`
    * `SortableCollection.BinarySearch()`

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Free Trainings @ Telerik Academy
* C# Programming @ Telerik Academy
    * csharpfundamentals.telerik.com
  * Telerik Software Academy
    * academy.telerik.com
  * Telerik Academy @ Facebook
    * facebook.com/TelerikAcademy
  * Telerik Software Academy Forums
    * forums.academy.telerik.com

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

