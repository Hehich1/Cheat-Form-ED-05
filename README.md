#ED 5-0 Case Reporting System
This project is a Python-based GUI application designed to implement a multi-stage Case Report Form system. Each stage of the case form is represented by a separate GUI interface, allowing users to fill out, save, and recall completed sections as individual files. The system ensures proper workflow control by locking previous stages upon submission and enabling access only to the next legal stage.

#Features
Stage-Based Form Management: Each stage is a separate GUI where users input case-related data. Once submitted, previous stages are locked for editing and become view-only.

File Handling: Users can open, save, and recall form data across sessions. Each completed stage is saved to a structured file for future reference.

Access Control: The system restricts user navigation to only legal stages based on workflow progression.

Administrative Dashboard: An overview panel allows administrative users to monitor all active cases and their current stages.

Keyword Detection Tool: Includes a feature for Deans and Department Chairs to search for keywords (e.g., "ChatGPT") across all form stages.

