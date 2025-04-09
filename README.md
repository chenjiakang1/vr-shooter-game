# vr-shooter-game
# 🎮 VR Shooter Game (Oculus Quest 2)

## 🧾 项目简介 | Project Overview | 프로젝트 소개

中文：  
这是一个基于 Unity 6 的 VR 射击游戏项目，目标平台为 Oculus Quest 2。本项目致力于打造一个沉浸式、真实感强的单人第一人称 VR 体验。玩家将在虚拟世界中与敌人交战，使用武器进行瞄准、射击与手动换弹，并可自由探索各类互动关卡。

游戏中包括完善的角色控制系统、基于 XR Interaction Toolkit 的互动机制、敌人 AI 状态机、以及模块化的动画系统和场景构建方案。该项目旨在作为一个完整的 VR 游戏开发学习范例，支持版本控制、多人协作开发，并计划集成 Jira 以进行任务管理与开发追踪。

English:  
This project is a VR shooter game built with Unity 6, targeting Oculus Quest 2. It aims to deliver an immersive single-player first-person VR experience, where players engage in gunfights with enemies, perform realistic manual reloading, and freely explore interactive game levels.

The game features a full player movement system, interaction logic powered by XR Interaction Toolkit, AI state machines for enemies, modular animation handling, and well-structured level design. It also serves as a learning project for VR development with proper version control, multi-developer collaboration, and future integration with Jira for agile task tracking and issue management.

한국어:  
이 프로젝트는 Unity 6를 기반으로 한 Oculus Quest 2용 VR 슈팅 게임입니다. 플레이어는 VR 환경 속에서 적과 교전하고, 현실적인 재장전과 조작을 통해 몰입감 있는 싱글 플레이어 1인칭 슈팅 경험을 하게 됩니다.

게임은 XR Interaction Toolkit을 기반으로 한 상호작용 시스템, 캐릭터 이동 및 시점 제어, 적 AI 상태 머신, 애니메이션 시스템, 모듈화된 레벨 구성 등을 포함합니다. 이 프로젝트는 버전 관리 및 협업 개발을 고려한 구조로 설계되었으며, 향후 Jira와 연동하여 개발 일정 및 이슈 관리를 효율화할 계획입니다.

---

## 核心功能 | Features | 주요 기능

中文：
- 沉浸式第一人称 VR 射击体验（FPS）
- 真实换弹机制（支持双手交互或控制器按钮）
- 敌人 AI 状态机系统（巡逻 / 攻击 / 被击退）
- 多场景开放式探索关卡（支持场景切换）
- XR Interaction Toolkit 全面支持（动作追踪、控制器输入）
- 支持 Meta Quest 2（可导出为 Android VR 包）

English:
- Immersive first-person VR shooting experience (FPS)
- Realistic manual reloading system (via two-hand or controller interaction)
- Enemy AI behavior with FSM (patrol, attack, retreat, etc.)
- Multi-scene, open-ended level design with seamless transition
- Full support for XR Interaction Toolkit (motion tracking, controller input)
- Optimized for Meta Quest 2 (builds for Android VR)

한국어:
- 몰입감 있는 1인칭 VR 슈팅 경험 (FPS)
- 현실적인 재장전 시스템 (양손 또는 컨트롤러 조작 지원)
- FSM 기반 적 AI 행동 로직 (순찰, 공격, 도망 등)
- 여러 개의 탐험 중심 레벨 설계 (장면 전환 지원)
- XR Interaction Toolkit 완전 통합 (동작 추적, 컨트롤러 입력)
- Meta Quest 2 최적화 (Android VR 빌드 가능)

---

##  技术栈 | Tech Stack | 기술 스택

中文：
- **Unity 6.0.0**：项目主引擎，负责渲染、物理、输入系统等
- **XR Interaction Toolkit**：实现 VR 交互系统、手柄追踪、手势操作等
- **Git + GitHub**：项目版本控制和多人协作平台
- *(计划)* **GitHub Actions**：自动化构建测试包、持续集成部署流程
- *(计划)* **Jira 集成**：通过 commit 消息自动关联任务、优化开发流程

English:
- **Unity 6.0.0**: Core engine for rendering, physics, and input management
- **XR Interaction Toolkit**: Powers all VR interactions including hand tracking and controller input
- **Git + GitHub**: For version control and team collaboration
- *(Planned)* **GitHub Actions**: Automate build process and CI/CD pipeline
- *(Planned)* **Jira Integration**: Link commits with tasks for better agile workflow

한국어:
- **Unity 6.0.0**: 렌더링, 물리, 입력 등을 담당하는 메인 엔진
- **XR Interaction Toolkit**: VR 상호작용, 컨트롤러 입력, 핸드 트래킹 등 지원
- **Git + GitHub**: 버전 관리 및 협업을 위한 도구
- *(예정)* **GitHub Actions**: 자동 빌드 및 CI/CD 구축
- *(예정)* **Jira 연동**: 커밋 메시지로 이슈 추적 및 작업 연결

---