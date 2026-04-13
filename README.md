![C#](https://img.shields.io/badge/C%23-Production%20Code-blue?logo=csharp)
![.NET](https://img.shields.io/badge/.NET-Application%20Development-512BD4?logo=dotnet)
![OOP](https://img.shields.io/badge/Design-OOP%20Principles-orange)
![Architecture](https://img.shields.io/badge/Architecture-Modular%20System-purple)
![Data Handling](https://img.shields.io/badge/Data-File%20I%2FO-green)
![Error Handling](https://img.shields.io/badge/Robustness-Exception%20Handling-red)
![Scalability](https://img.shields.io/badge/Code-Clean%20Architecture-blue)
![Status](https://img.shields.io/badge/Status-Portfolio%20Ready-brightgreen)
![Last Commit](https://img.shields.io/github/last-commit/Trojan3877/Software3-Lab)
![Repo Size](https://img.shields.io/github/repo-size/Trojan3877/Software3-Lab)
![Stars](https://img.shields.io/github/stars/Trojan3877/Software3-Lab?style=social)


**Software3-Lab** is a **production-style AI system** that combines:

- Classical Machine Learning
- Experiment tracking (MLflow)
- LLM-based orchestration (GPT-4)
- Model Control Plane (MCP) architecture
- FastAPI service layer
- CI/CD + Docker parity

This project demonstrates **how modern AI systems are actually built in industry**.



## 🧠 Architecture Overview
User / API Request ↓ FastAPI Service ↓ LLM MCP Agent (GPT-4) ↓ LangChain Tools ↓ ML Training / Evaluation ↓ MLflow Metrics & Artifacts



 Key Components

### 1. Machine Learning Layer
- Algorithm: Logistic Regression
- Dataset: Iris
- Framework: Scikit-learn
- Metrics logged via MLflow

### 2. LLM Model Control Plane (MCP)
- LLM: GPT-4
- Framework: LangChain
- Pattern: Tool-based orchestration
- Separation of reasoning and execution

### 3. API Layer
- Framework: FastAPI
- Swagger UI enabled
- Safe, auditable LLM execution

### 4. Experiment Tracking
- MLflow for parameters, metrics, and models
- Reproducible experiments
- CI-validated training



Tech Stack

| Layer | Technology |
|----|----|
| ML | Scikit-learn |
| LLM | GPT-4 |
| MCP | LangChain |
| Tracking | MLflow |
| API | FastAPI |
| CI/CD | GitHub Actions |
| Container | Docker |
| Language | Python 3.10 |



Metrics & Evaluation

Detailed performance metrics, experiment logs, and system evaluation are available in:

➡ **[`Metrics.md`](Metrics.md)**

---
docker build -t software3-lab .
docker run -p 8000:8000 software3-lab


## ▶️ How to Run

### Local
```bash
pip install -r requirements.txt
uvicorn src.api:app --reload
http://localhost:8000/docs

Future Enhancements

RAG over experiment history

Model registry promotion

Performance regression alerts

Multi-agent orchestration

Design Questions & Reflections
Q: What problem does this project aim to solve?
A: This project was built to explore core software engineering principles in a structured lab environment, focusing on clean code organization, object-oriented design, and feature implementation practices that mirror real application development. The goal was to go beyond small scripts and build something with modularity and maintainability in mind.
Q: Why did I choose this design and approach instead of something simpler?
A: I chose to emphasize clear separation of concerns and object-oriented patterns so that each component of the system could evolve independently and be easily tested. This was more work than quickly prototyping a single file, but it improved readability, reusability, and made debugging easier over time.
Q: What were the main trade-offs I made?
A: The trade-off was between speed of initial development and long-term clarity. I could have sketched the whole thing in a few files, but I would have lost structure and future scalability. By investing in a solid project layout and explicit module boundaries, I traded some early speed for maintainability and extensibility.
Q: What didn’t work as expected?
A: Some parts of the implementation didn’t perform as efficiently as I anticipated when handling edge cases or larger input sizes. Addressing these required reevaluating data structures and logic flows, which helped me refine both performance considerations and code clarity.
Q: What did I learn from building this project?
A: I learned the value of starting with a solid design foundation and how important it is to think about how future changes will affect an entire system. I also gained deeper insights into debugging practices, version control workflows, and how incremental updates can improve both quality and readability.
Q: If I had more time or resources, what would I improve next?
A: I would build out a more comprehensive test suite and add automated testing so that each module could be verified independently. I’d also try to gather user feedback or usage patterns to further refine functionality and polish the user experience.
