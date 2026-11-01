# CSCU Game Development Project
Welcome! This is the repository for the CSCU's game development project.

**Project Lead**: Carson Bennett

## Project Requirements
|Application|Version|Purpose|Install Location|
|-----------|-------|-------|----------------|
|Unity|Unity 6000.6.4f1 - MUST be exact version|Game engine that runs the game and allows for modelling, animation, and scripting integrations.|For those who don't have Unity: https://unity.com/products/unity-personal (requires account creation) For those who need the specific version: https://unity.com/releases/editor/archive|
|Visual Studio Code|Any recent version|Scripting|https://code.visualstudio.com/download|

## Repository Cloning Instructions

#### 1. Cloning
1. Create a local folder where you'd like to hold the project on your laptop (Ideally outside the reach of a cloud service)
2. In VS Code, open the terminal (`Ctrl+Shift+U`/`Cmd+Shift+U`)
3. Navigate to your folder on the terminal
4. Type `git clone https://github.com/cscu-ok/Mansion-Crawler.git` and hit enter
5. Navigate to project folder `cd mansion-crawler`

#### 2. Unity Integration
1. Open Unity Hub > Add > Add project from disk
2. Navigate to cloned project folder and select it
3. Ensure you're using the correct Unity version (6000.6.4f1)

#### 3. Visual Studio Code Integration
1. In Unity, go to Edit > Preferences > External Tools
2. Set "External Script Editor" to "Visual Studio Code"
3. Click "Regenerate project files"
4. Verify integration by double clicking on a C# (.cs) file in Unity - should open up VS Code editor.

## Version Control Basics
Below are some steps of basic version control:
1. Before starting work, always pull from main (`git pull origin main`)
2. Make sure to branch out from main before working in Unity of VS Code (New branch: `git checkout -b <<your-branch-name>>` Existing branch: `git checkout <<your-branch-name>>`)
3. Save changes frequently, and when ready to commit, you can use VS Code's built in panel, or through the terminal by following the steps below:

If first time pushing the branch to GitHub, set the upstream tracking link:
```bash
git add .                                    # stage all changes
git commit -m "your commit message here"     # commit with message
git push -u origin feature/your-feature-name    # push to GitHub
```

On subsequent commits to the same branch, simply do:
```bash
git add .
git commit -m "your commit message here"
git push
```

4. When ready for code to be merged with main, open a pull request through the GitHub online repository.

## Theme
Top down/2D dungeon crawler where our main character tries to escape while navigating puzzles in various connected rooms. Rooms while have different puzzles and occasional enemies. Our game's twist will be an unkillable antagonist that presents itself halfway through the game. 
The player must outmaneuver this enemy to create time and space to continue working on their escape.

## Roadmap
|Month|Deliverables|
|-----|------------|
|November|Connected rooms with player progression, work on enemies, work on pursuer|
|December|Continued work on game rooms and puzzles, continued work on pursuer and enemy AI|
|January|Work on overall game styling, add audio, add UI menu, save system|
|February|Internal testing (Dev team first, then CSCU), test game flow, enemy AI, pursuer AI, puzzle difficulty styling, add suggested changes|
|March|External play testing (friends, family, non-CSCU event goers), integrate suggested feedback|
|April|Buffer for any items that need to be pushed back or final changes, create handover document|


