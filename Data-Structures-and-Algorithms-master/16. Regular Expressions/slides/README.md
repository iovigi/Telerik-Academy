<!-- section start -->
<!-- attr: { class:'slide-title', hasScriptWrapper: true, showInPresentation:true, style:'' } -->
# Regular Expressions in JS
##  Fast ways to search and replace string

<div class="signature">
    <p class="signature-course">Data Structures and Algorithms</p>
    <p class="signature-initiative">Telerik Software Academy</p>
    <a href="http://academy.telerik.com" class="signature-link">http://academy.telerik.com</a>
</div>

<!-- attr: { showInPresentation:true, style:'' } -->
# Table of Contents

- Regular Expression Overview
- Special Characters for beginning and end
- Regex in JavaScript
  - Regex literal and RegExp function constructor
- Special Characters in Regex

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Regular Expressions
##  Overview

<!-- attr: { showInPresentation:true, style:'' } -->
# Regular Expressions Overview
- A regular expression is a set of patterns used to match character combinations in strings
  - Find and extract data from a document
  - Validate content supplied in a form before it is submitted like:
    - Telephone numbers
    - SSN/EGN
    - Email addresses
    - Anything that follows a pattern

<!-- attr: { showInPresentation:true, style:'' } -->
# Regex Syntax
- Regular expressions are an extremely powerful tool implemented in most languages
- Yet, regular expressions have their own syntax and usage of special characters
  - Difficult to remember if you use them infrequently
- Regular expressions can be tested at:
  - http://www.regexr.com/

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Regex Special Characters for Beginning and End
##  `^` and `$`

<!-- attr: { showInPresentation:true, style:'' } -->
# Regex Special Characters for Beginning and End
- Special Characters:
  - `^` - matches the beginning of input
    - `^T`
      - Matches: 'Telerik Academy', 'Telerik', 'Theta'
      - Does not match: 'Academy', 'Good Telerik'
  - `$` - matches the end of input
    - `y$`
      - Matches: 'Telerik Academy', 'Academy', 'yummy'
      - Does not match: 'Telerik', 'Good Telerik'

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Regex Special Characters for Beginning and End -->
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Special Characters in Regular Expressions
##  For matching all kinds of stuff

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex
- The regular expressions have a set of special characters, that have a different behavior
  - Characters for matching multiple characters
  - Characters for matching whitespace
  - Characters for matching digits
  - Characters for matching letters
  - Etc…
- Full list of special characters can be found at:
  - https://developer.mozilla.org/en/docs/Web/JavaScript/Guide/Regular_Expressions#Using_special_characters

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex: `x`
- Special Characters in Regex:
  - `*` – The preceding character is matched 0 or more times
    - `a*`
      - Matches: alaaaaaa bala'
      - Does not match: 'Good Telerik', 'Doncho Minkov'
      - Remark: `Da*oncho`
        - Matches: 'Doncho Minkov'
        - 'a' is matched 0 times

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: x -->
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex: `+`
- Special Characters in Regex:
  - `+` – The preceding character is matched 1 or more times
    - `a+`
      - Matches: 'alaaaaaa bala'
      - Does not match: 'Doncho Minkov', 'Good Telerik'
    - Remark:
      - Does not match: 'Doncho Minkov'
- a+
- Da+oncho

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: + -->
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex: `?`
- Special Characters in Regex:
  - `?` – The preceding character is matched 0 or 1 times
    - `T?`
      - Matches: 'Telerik is Telerik'
      - Does not match: 'Academy'

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: ? -->
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex: `.`(dot)
- Special Characters in Regex:
  - .(dot) – matches any single character except the newline character
    - `.`
    - Matches: 'Telerik is Telerik'
    - Remark:
      - `.*`
      - Matches any whole string

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: . (dot) -->
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex: `|`
- Special Characters in Regex:
  - `|` – Matches one pattern or the other
    -        
    - Matches: 'Telerik Academy'
- T|A

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: | -->
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex: `[ ]`
- Special Characters in Regex:
  - `[xyz]` – Character set
    - Matches any one of the enclosed characters
    -        
    - Matches: 'Telerik Academy'
- [TAy]

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: [ ] -->
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex: `[ ]`
- Special Characters in Regex:
  - `[x-z]` – Character set
    - Matches any one between the characters range
    -        
    - Matches: 'Telerik Academy'
    -  
    - Matches: 'Telerik Academy'
    -  
    - Matches: 'Telerik Academy'
    -  
    - Matches: 'John in 19-years-old'
- [A-Z]
- [A-z]
- [a-q]
- [0-9]

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: [ ] Range -->
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex: [^xyx]
- Special Characters in Regex:
  - `[^xyx]` – A negated or complemented character set
    - Matches anything that is not enclosed in the brackets       
    -  
    - Matches: 'Telerik Academy'
    - Does not match: 'eaaaaeeeaaa', 'aaaa', 'eeee'
- [^ea]+

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: [^xyz] -->
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex: {}
- Special Characters in Regex:
  - `{N}` – matches exactly `N` occurrences       
    - Where `N` is a positive number
    -  
    - Matches: 'Telerik Academy', 'Doncho Minkov'
    - Does not match: 'JS is the best'
- [A-z]{5}
  - `{N, M}` – matches at least `N` and at most `M` occurrences of the preceding character
    - Where `N` and `M` are positive integers
    -   
    - Matches: 'Telerik Academy', 'JS is best'
    - Does not match: 'Ivo is the MAN'
- [A-z]{4, 5}

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: {} -->
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# Other Special Characters in Regex
- Special Characters in Regex:
  - `/s` – matches a single white space character, including space, tab, form feed, line feed
  - `/S `– matches a single character other than white space
  - `/d` – matches a digit character
    - Equivalent to `[0-9]`
  - `/D` – matches any non-digit character
    - Equivalent to `[^0-9]`
  - `/w` – matches any alphanumeric character including the underscore
  - `/W` – matches any non-alphanumeric or underscore character
- Matches a digit character. Equivalent to [0-9].

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Other Special Characters in Regular Expressions -->
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Regular Expression Flags

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Regular Expression Flags
- Regular expression have optional flags that allow for global and case insensitive searching
  - These flags can be used separately or together in any order

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Regular Expression Flags -->
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# Regular Expressions in JS
- http://academy.Telerik.com

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Free Trainings @ Telerik Academy
- "Web Design with HTML 5, CSS 3 and JavaScript" course @ Telerik Academy
    - html5course.telerik.com
  - Telerik Software Academy
    - academy.telerik.com
  - Telerik Academy @ Facebook
    - facebook.com/TelerikAcademy
  - Telerik Software Academy Forums
    - forums.academy.telerik.com

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />
